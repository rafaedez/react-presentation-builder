using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PresentationBuilder.WebAPI.Models;

namespace PresentationBuilder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PresentationController : Controller
    {
        private readonly IPresentationRepository presentationRepository;
        public PresentationController(IPresentationRepository presentationRepository)
        {
            this.presentationRepository = presentationRepository;
        }

        [HttpGet]
        public IEnumerable<Presentation> Get()
        {
            return this.presentationRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = this.presentationRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Presentation item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            this.presentationRepository.Add(item);

            return CreatedAtRoute("Get", new { id = item.PresentationID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Presentation item)
        {
            if (item == null || item.PresentationID != id)
            {
                return BadRequest();
            }

            var presentation = this.presentationRepository.Find(id);
            if (presentation == null)
            {
                return NotFound();
            }

            presentation.Name = item.Name;
            presentation.Description = item.Description;

            this.presentationRepository.Update(presentation);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var presentation = this.presentationRepository.Find(id);
            if (presentation == null)
            {
                return NotFound();
            }

            this.presentationRepository.Remove(id);
            return new NoContentResult();
        }

    }
}
