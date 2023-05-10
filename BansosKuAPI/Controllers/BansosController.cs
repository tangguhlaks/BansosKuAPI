using BansosKuAPI.Interface;
using BansosKuAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BansosKuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BansosController : ControllerBase
    {
        private readonly IBansosRepository _repository;
        private readonly IAuthRepository _repositoryUser;
        Random random = new Random();
        public BansosController(IBansosRepository repository,IAuthRepository authRepository)
        {
            _repository = repository;
            _repositoryUser = authRepository;
        }
        [HttpGet("GetBansos")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Bansos>))]
        public IActionResult GetBansos()
        {
            var users = _repository.GetBansos();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);
        }

        [HttpGet("GetBansosById/{id}")]
        [ProducesResponseType(200, Type = typeof(Bansos))]
        public IActionResult GetBansosById(int id)
        {
            var data = _repository.GetBansosById(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(data);
        }

        [HttpDelete("DeletBansos/{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult DeleteBansos(int id)
        {
            var bansos = _repository.GetBansosById(id);
            if(bansos != null)
            {
                try
                {
                    _repository.DeleteBansos(bansos);
                    return Ok(true);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    return Ok(false);
                }
            }
            else
            {
                return NotFound();
            }
            return Ok(false);
        }

        [HttpPost("AddBansos")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddBansos([FromBody] BansosVM bansos) {
            if(bansos == null)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Bansos u = new Bansos(_repository.GetBansos().Count() + 1,bansos.Nama,bansos.Tanggal,bansos.Deskripsi,bansos.Lokasi,bansos.Image);
                var id = _repository.AddBansos(u);
                return Ok(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return Ok(-1);
        }

        [HttpPost("AddBansosUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddBansosUser([FromBody] TrxBansos bansos)
        {
            if (bansos == null)
            {
                return BadRequest(ModelState);
            }
            try
            {
                TrxBansos u = new TrxBansos(random.Next(1000
                    ),bansos.BansosId,bansos.UserId,bansos.Status);
                var id = _repository.AddBansosUser(u);
                return Ok(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return Ok(-1);
        }
        [HttpGet("GetBansosUser/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult GetBansosUser(int id)
        {
            try
            {
                var res = _repository.GetBansosUser(id);
                foreach (var item in res)
                {
                    item.User = _repositoryUser.GetUserById(Convert.ToInt32(item.User)).Fullname;
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return Ok(-1);
        }

        [HttpPut("UpdateBansos/{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateBansos(int id,[FromBody] BansosVM bansos)
        {
            if (bansos == null)
                return BadRequest(ModelState);
            if (id == null)
                return BadRequest(ModelState);

            var cek = _repository.GetBansosById(id);
            if(cek == null)
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Bansos data = new Bansos(id, bansos.Nama, bansos.Tanggal, bansos.Deskripsi, bansos.Lokasi,bansos.Image);
                _repository.UpdateBansos(data);
                return Ok("success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return Ok("failed");
        }
    }
}
