using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceReservasi_015
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string pemesanan(string IDPemesanan, string NamaCustomer, string NoTelepon, string JumlahPemesan, string IDLokasi);

        [OperationContract]
        string editPemesanan(string IDPemesanan, string NamaCustomer);

        [OperationContract]
        string deletePemesanan(string IDPemesanan);

        [OperationContract]
        List<CekLokasi> ReviewLokasi();

        [OperationContract]
        List<DetailLokasi> DetailLokasi();

        [OperationContract]
        List<Pemesanan> Pemesanan();
       

        
    }

    public class Pemesanan
    {
        [DataMember]
        public string IDLokasi { get; set; }

        [DataMember]
        public string NamaLokasi { get; set; }

        [DataMember]
        public string DeskripsiSingkat { get; set; }

    }

    public class DetailLokasi
    {
        [DataMember]
        public string IDLokasi { get; set; }

        [DataMember]
        public string NamaLokasi { get; set; }

        [DataMember]
        public string DeskripsiFull { get; set; }

        [DataMember]
        public int Kuota { get; set; }
    }

    public class CekLokasi
    {
        [DataMember]
        public string IDPemesan { get; set; }

        [DataMember]
        public string NamaCustomer { get; set; }

        [DataMember]
        public string NoTelepon { get; set; }

        [DataMember]
        public int JumlahPemesan { get; set; }

        [DataMember]
        public string IDLokasi { get; set; }


    }
}
