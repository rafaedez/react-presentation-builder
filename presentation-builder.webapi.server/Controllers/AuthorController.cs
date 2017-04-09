using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PresentationBuilder.WebAPI.Models;

namespace PresentationBuilder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository AuthorRepository;
        public AuthorController(IAuthorRepository AuthorRepository)
        {
            this.AuthorRepository = AuthorRepository;
        }

        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return this.AuthorRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = this.AuthorRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Author item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            this.AuthorRepository.Add(item);

            return CreatedAtRoute("Get", new { id = item.AuthorID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Author item)
        {
            if (item == null || item.AuthorID != id)
            {
                return BadRequest();
            }

            var Author = this.AuthorRepository.Find(id);
            if (Author == null)
            {
                return NotFound();
            }

            Author.Name = item.Name;
            Author.Email = item.Email;

            this.AuthorRepository.Update(Author);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var Author = this.AuthorRepository.Find(id);
            if (Author == null)
            {
                return NotFound();
            }

            this.AuthorRepository.Remove(id);
            return new NoContentResult();
        }

    }
}
