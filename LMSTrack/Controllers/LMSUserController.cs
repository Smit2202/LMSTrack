using LMSTrack.Services.LMSServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LMSTrack.Services.LMSServices;
using static LMSTrack.Model.ModelClass;

namespace LMSTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LMSUserController : ControllerBase
    {
        private readonly ILMSUserServices _lMSuserServices;

        public LMSUserController(ILMSUserServices lMSuserServices)
        {
            _lMSuserServices = lMSuserServices;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _lMSuserServices.GetUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return Ok(await _lMSuserServices.GetUser(id));
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<List<User>>> PostUser(User user)
        {
            var result = await _lMSuserServices.PostUser(user);
            return Ok(result);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            var result = await _lMSuserServices.PutUser(id, user);
            if (result is null)
                return NotFound("Hero not found.");

            return Ok(result);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _lMSuserServices.DeleteUser(id);
            if (result is null)
                return NotFound("Hero not found.");

            return Ok(result);
        }
    }
}
