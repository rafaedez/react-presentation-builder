using System;
using System.Collections.Generic;
using System.Linq;
using PresentationBuilder.WebAPI.Data;

namespace PresentationBuilder.WebAPI.Models
{
    public class PageRepository : IPageRepository
    {
        private readonly PresentationContext context;

        public PageRepository(PresentationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Page> GetAll()
        {
            return this.context.Pages.ToList();
        }

        public void Add(Page item)
        {
            this.context.Pages.Add(item);
            this.context.SaveChanges();
        }

        public Page Find(long id)
        {
            return this.context.Pages.FirstOrDefault(t => t.PageID == id);
        }

        public void Remove(long id)
        {
            var entity = this.context.Pages.First(t => t.PageID == id);
            this.context.Pages.Remove(entity);
            this.context.SaveChanges();
        }

        public void Update(Page item)
        {
            this.context.Pages.Update(item);
            this.context.SaveChanges();
        }
    }
}