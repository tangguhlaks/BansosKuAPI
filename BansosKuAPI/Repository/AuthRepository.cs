using BansosKuAPI.Interface;
using BansosKuAPI.Model;

namespace BansosKuAPI.Repository
{
    public class AuthRepository : IAuthRepository
    {
        List<User> _users = new List<User>();

        public int AddUser(User user)
        {
            try
            {
                _users.Add(user);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return -1;
            }
            return user.Id;
        }

        public bool Authentication(string nik, string password)
        {
            var cek = _users.Where(x => x.NIK == nik && x.Password == password).Count();
            if(cek > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteUser(User user)
        {
            try
            {
                _users.Remove(user);
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return false;
        }

        public User GetUserById(int id)
        {
            return _users.Where(x => x.Id == id).First();
        }

        public ICollection<User> GetUsers()
        {
            return _users.OrderBy(x=>x.Id).ToList();
        }

        public bool UpdateUser(User user)
        {
            try
            {
                var data = _users.Where(x => x.Id == user.Id).First();
                data.Fullname = user.Fullname;
                data.NIK = user.NIK;
                data.Role = user.Role;
                data.Password = user.Password;
                data.Alamat = user.Alamat;
                data.FotoKTP = user.FotoKTP;
                data.Pendapatan = user.Pendapatan;
                data.FotoRumah = user.FotoRumah;
              
                return true;
            }catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message.ToString());
            }
            return false;

        }
    }
}
