namespace BansosKuAPI.Model
{
    public class TrxBansos
    {
        public int Id { get; set; }
        public int BansosId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public TrxBansos() { 
        
        }
        public TrxBansos(int id, int bansosId, int userId, string status)
        {
            Id = id;
            BansosId = bansosId;
            UserId = userId;
            Status = status;
        }   
    }
}
