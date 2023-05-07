using BansosKuAPI.Model;

namespace BansosKuAPI.Interface
{
    public interface IAuthRepository
    {
        ICollection<User> GetUsers();
        int AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        User GetUserById(int id);
        bool Authentication(string nik, string password);
    }
}
