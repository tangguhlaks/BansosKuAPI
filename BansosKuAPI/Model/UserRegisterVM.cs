namespace BansosKuAPI.Model
{
    public class UserRegiserVM
    {
        public string NIK { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public UserRegiserVM() { }
        public UserRegiserVM(string nIK, string fullname, string password, string role)
        {
            NIK = nIK;
            Fullname = fullname;
            Password = password;
            Role = role;
        }
    }
}
