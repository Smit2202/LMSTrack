using Azure.Core;
using LMSTrack.Data;
using LMSTrack.Services.LMSServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static LMSTrack.Model.ModelClass;

namespace LMSTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LMSController : ControllerBase
    {
        private readonly ILMSServices _lMSServices;

        public LMSController(ILMSServices lMSServices)
        {
            _lMSServices = lMSServices;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _lMSServices.GetBooks();
        }

        //// GET: api/Books/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Book>> GetBook(int id)
        //{
        //    return Ok(await _lMSServices.GetBook(id));
        //}

        // GET: api/Users/titlename
        [HttpGet("{title}")]
        public async Task<ActionResult<Book>> GetBookbyname(string title)
        {
            return Ok(await _lMSServices.GetBookbyname(title));
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<List<Book>>> PostBook(Book book)
        {
            var result = await _lMSServices.PostBook(book);
            return Ok(result);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            var result = await _lMSServices.PutBook(id, book);
            if (result is null)
                return NotFound("Hero not found.");

            return Ok(result);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _lMSServices.DeleteBook(id);
            if (result is null)
                return NotFound("Hero not found.");

            return Ok(result);
        }
    }
}
