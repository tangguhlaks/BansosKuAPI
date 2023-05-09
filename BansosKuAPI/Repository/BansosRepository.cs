using BansosKuAPI.Interface;
using BansosKuAPI.Model;

namespace BansosKuAPI.Repository
{
    public class BansosRepository : IBansosRepository
    {
        List<Bansos> _data = new List<Bansos>();

        public int AddBansos(Bansos bansos)
        {
            try
            {
                _data.Add(bansos);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return -1;
            }
            return bansos.Id;
        }

        public bool DeleteBansos(Bansos bansos)
        {
            try
            {
                _data.Remove(bansos);
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return false;
        }

        public Bansos GetBansosById(int id)
        {
            return _data.Where(x => x.Id == id).First();
        }

        public ICollection<Bansos> GetBansos()
        {
            return _data.OrderBy(x=>x.Id).ToList();
        }

        public bool UpdateBansos(Bansos bansos)
        {
            try
            {
                var data = _data.Where(x => x.Id == bansos.Id).First();
                data.Tanggal = bansos.Tanggal;
                data.Nama = bansos.Nama;
                data.Deskripsi = bansos.Deskripsi;
                data.Lokasi = bansos.Lokasi;
                data.Image = bansos.Image;
                return true;
            }catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message.ToString());
            }
            return false;

        }

    }
}
