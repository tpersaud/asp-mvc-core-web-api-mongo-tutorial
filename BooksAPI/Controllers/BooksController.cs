using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksAPI.Models;
using BooksAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly BookService _bookServices;

        public BooksController(BookService bookService)
        {
            _bookServices = bookService;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return _bookServices.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(string id)
        {
            var book = _bookServices.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Book> Post([FromBody]Book book)
        {
            _bookServices.Create(book);
            return CreatedAtAction(nameof(Get), new { id = book.Id.ToString() }, book);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]Book bookUpdate)
        {
            var book = _bookServices.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookServices.Update(id, bookUpdate);

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var book = _bookServices.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
