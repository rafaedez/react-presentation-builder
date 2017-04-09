using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PresentationBuilder.WebAPI.Models;

namespace PresentationBuilder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PageController : Controller
    {
        private readonly IPageRepository PageRepository;
        public PageController(IPageRepository PageRepository)
        {
            this.PageRepository = PageRepository;
        }

        [HttpGet]
        public IEnumerable<Page> Get()
        {
            return this.PageRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = this.PageRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Page item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            this.PageRepository.Add(item);

            return CreatedAtRoute("Get", new { id = item.PageID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Page item)
        {
            if (item == null || item.PageID != id)
            {
                return BadRequest();
            }

            var page = this.PageRepository.Find(id);
            if (page == null)
            {
                return NotFound();
            }

            page.Image = item.Image;
            page.Audio = item.Audio;
            page.AudioTime = item.AudioTime;
            page.index = item.index;

            this.PageRepository.Update(page);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var Page = this.PageRepository.Find(id);
            if (Page == null)
            {
                return NotFound();
            }

            this.PageRepository.Remove(id);
            return new NoContentResult();
        }

    }
}
