namespace BansosKuAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        public string NIK { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public User() { }
        public User(int id, string nIK, string fullname, string password, string role)
        {
            Id = id;
            NIK = nIK;
            Fullname = fullname;
            Password = password;
            Role = role;
        }
    }
}
