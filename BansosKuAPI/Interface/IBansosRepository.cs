using BansosKuAPI.Model;

namespace BansosKuAPI.Interface
{
    public interface IBansosRepository
    {
        ICollection<Bansos> GetBansos();
        int AddBansos(Bansos bansos);
        bool UpdateBansos(Bansos bansos);
        bool DeleteBansos(Bansos bansos);
        Bansos GetBansosById(int id);
    }
}
