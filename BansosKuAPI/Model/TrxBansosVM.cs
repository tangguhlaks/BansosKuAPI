namespace BansosKuAPI.Model
{
    public class TrxBansosVM
    {
        public int Id { get; set; }
        public string Bansos { get; set; }
        public string User { get; set; }
        public string Tanggal { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }
        public TrxBansosVM() { }
        public TrxBansosVM(int id, string bansos, string user, string tanggal, string status, string image)
        {
            Id = id;
            Bansos = bansos;
            User = user;
            Tanggal = tanggal;
            Status = status;
            Image = image;
        }
    }
}
