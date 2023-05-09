namespace BansosKuAPI.Model
{
    public class BansosVM
    {
        public string Nama { get; set; }
        public string Tanggal { get; set; }
        public string Deskripsi { get; set; }
        public string Lokasi { get; set; }
        public string Image { get; set; }
        public BansosVM() { 
        }
        public BansosVM(string nama, string tanggal, string deskripsi, string lokasi,string image)
        {
            Nama = nama;
            Tanggal = tanggal;
            Deskripsi = deskripsi;
            Lokasi = lokasi;
            Image = image;
        }
    }
}
