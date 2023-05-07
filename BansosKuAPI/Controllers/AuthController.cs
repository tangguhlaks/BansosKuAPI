using BansosKuAPI.Interface;
using BansosKuAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BansosKuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        Random random = new Random();
        public AuthController(IAuthRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("GetUsers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var users = _repository.GetUsers();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);
        }

        [HttpGet("GetUserById/{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        public IActionResult GetUserById(int id)
        {
            var user = _repository.GetUserById(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(user);
        }

        [HttpDelete("DeletUser/{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult DeleteUser(int id)
        {
            var user = _repository.GetUserById(id);
            if(user != null)
            {
                try
                {
                    _repository.DeleteUser(user);
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

        [HttpGet("Authentication/{nik}/{password}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Authentication(string nik,string password)
        {
            var cekAuth = _repository.Authentication(nik, password);
            if (cekAuth)
            {
                var user = _repository.GetUsers().Where(x => x.NIK == nik && x.Password == password).First();
                return Ok(user);
            }
            return Ok(false);
        }

        [HttpPost("AddUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddUser([FromBody] User user) {
            if(user == null)
            {
                return BadRequest(ModelState);
            }
            var cekNik = _repository.GetUsers().Where(x=>x.NIK == user.NIK).Count();
            if(cekNik > 0)
            {
                return Ok("NIK Already Exists");
            }
            try
            {
                user.Id = _repository.GetUsers().Count() + 1; ;
                var id = _repository.AddUser(user);
                return Ok(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return Ok(-1);
        }

        [HttpPut("UpdateUser/{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateUser(int id,[FromBody] User user)
        {
            if (user == null)
                return BadRequest(ModelState);
            if (id == null)
                return BadRequest(ModelState);

            var cekUser = _repository.GetUserById(id);
            if(cekUser == null)
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                user.Id =id;
                _repository.UpdateUser(user);
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
