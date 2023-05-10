using BansosKuAPI.Interface;
using BansosKuAPI.Model;

namespace BansosKuAPI.Repository
{
    public class BansosRepository : IBansosRepository
    {
        List<Bansos> _data = new List<Bansos>();
        List<TrxBansos> _trxData = new List<TrxBansos>();

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

        public int AddBansosUser(TrxBansos trx)
        {
            try
            {
                _trxData.Add(trx);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return -1;
            }
            return trx.Id;
        }

        public List<TrxBansosVM> GetBansosUser(int id)
        {
            List<TrxBansos> tmpres = _trxData.Where(x => x.UserId == id).ToList();
            List<TrxBansosVM> res = new List<TrxBansosVM>();
            foreach (var item in tmpres)
            {
                TrxBansosVM tmp = new TrxBansosVM(item.Id,_data.Where(x => x.Id == item.BansosId).First().Nama,item.UserId.ToString(), _data.Where(x => x.Id == item.BansosId).First().Tanggal, item.Status,"-");
                res.Add(tmp);
            }

            return res;
        }
    }
}
