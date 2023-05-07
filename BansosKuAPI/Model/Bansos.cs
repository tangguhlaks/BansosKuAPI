namespace BansosKuAPI.Model
{
    public class Bansos
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Tanggal { get; set; }
        public string Deskripsi { get; set; }
        public string Lokasi { get; set; }
        public Bansos() { 
        }
        public Bansos(int id, string nama, string tanggal, string deskripsi, string lokasi)
        {
            Id = id;
            Nama = nama;
            Tanggal = tanggal;
            Deskripsi = deskripsi;
            Lokasi = lokasi;
        }
    }
}
