using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceReservasi_015
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        string constring = "Data Source=DZALFIQ\\DZALFIQRISABANI;Initial Catalog=WCFReservasi;Integrated Security=True";
        SqlConnection connection;
        SqlCommand cmd;

        public string pemesanan(string IDPemesanan, string NamaCustomer, string NoTelepon, int JumlahPemesan, string IDLokasi)
        {
            string a = "gagal";
            try
            {
                string sql = "insert into dbo.Pemesanan values('" + IDPemesanan + "','" + NamaCustomer + "','" + NoTelepon + "', " +
                   "" + JumlahPemesan + ",'" + IDLokasi + "')";

                connection = new SqlConnection(constring);
                cmd = new SqlCommand(sql, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                string sql2 = "update dbo.Lokasi set Kuota = Kuota - " + JumlahPemesan + " where ID_Lokasi = '"+IDLokasi+"' ";

                connection = new SqlConnection(constring);
                cmd = new SqlCommand(sql2, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();


                a = "sukses";

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return a;
        }

        public string editPemesanan(string IDPemesanan, string NamaCustomer, string No_telepon)
        {
            String a = "Gagal";
            try
            {

                string sql = "update dbo.Pemesanan set Nama_customer = '" + NamaCustomer + "', No_telepon = '" + No_telepon + "', where ID_reservasi = '" + IDPemesanan + "' ";

                connection = new SqlConnection(constring);
                cmd = new SqlCommand(sql, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();


                a = "sukses";

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return a;
        }

        public string deletePemesanan(string IDPemesanan)
        {
            string a = "Gagal";
            try
            {
                string sql = "DELETE FROM dbo.Pemesanan WHERE ID_reserasi = '" + IDPemesanan +"'";
                connection = new SqlConnection(constring);
                cmd = new SqlCommand(sql, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                a = "Sukses";
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return a;
        }

        public List<DetailLokasi> DetailLokasi()
        {
            List<DetailLokasi> lokasiFull = new List<DetailLokasi>();
            try
            {
                string sql = "select ID_Lokasi, Nama_lokasi, Deskripsi_full, Kuota from dbo.Lokasi";
                connection = new SqlConnection(constring);
                cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DetailLokasi data = new DetailLokasi();
                    data.IDLokasi = reader.GetString(0);
                    data.NamaLokasi = reader.GetString(1);
                    data.DeskripsiFull = reader.GetString(2);
                    data.Kuota = reader.GetInt32(3);
                    lokasiFull.Add(data);
                }
                connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            return lokasiFull;
        }

        public List<Pemesanan> Pemesanan()
        {
            List<Pemesanan> Pemesanans = new List<Pemesanan>();
            try
            {
                string sql = "select ID_reservasi, Nama_customer, No_telepon, Jumlah_Pemesanan, Nama_lokasi from dbo.Pemesanan p INNER JOIN dbo.Lokasi l ON l.ID_Lokasi = p.ID_lokasi";
                connection = new SqlConnection(constring);
                cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Pemesanan data = new Pemesanan();
                    data.IDPemesan = reader.GetString(0);
                    data.NamaCustomer = reader.GetString(1);
                    data.NoTelepon = reader.GetString(2);
                    data.JumlahPemesan = reader.GetInt32(3);
                    data.Lokasi = reader.GetString(4);
                    Pemesanans.Add(data);
                    
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return Pemesanans;
        }

        public List<CekLokasi> ReviewLokasi()
        {
            List<CekLokasi> lokasiSingkat = new List<CekLokasi>();
            try
            {
                string sql = "select ID_lokasi, Nama_lokasi, Deskripsi_singkat from dbo.Lokasi";
                connection = new SqlConnection(constring);
                cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CekLokasi data = new CekLokasi();
                    data.IDLokasi = reader.GetString(0);
                    data.NamaLokasi = reader.GetString(1);
                    data.DeskripsiSingkat = reader.GetString(2);
                    lokasiSingkat.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return lokasiSingkat;
        }

        
    }
}