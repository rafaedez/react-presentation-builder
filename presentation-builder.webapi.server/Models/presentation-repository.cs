using System;
using System.Collections.Generic;
using System.Linq;
using PresentationBuilder.WebAPI.Data;

namespace PresentationBuilder.WebAPI.Models
{
    public class PresentationRepository : IPresentationRepository
    {
        private readonly PresentationContext context;

        public PresentationRepository(PresentationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Presentation> GetAll()
        {
            return this.context.Presentations.ToList();
        }

        public void Add(Presentation item)
        {
            this.context.Presentations.Add(item);
            this.context.SaveChanges();
        }

        public Presentation Find(long id)
        {
            return this.context.Presentations.FirstOrDefault(t => t.PresentationID == id);
        }

        public void Remove(long id)
        {
            var entity = this.context.Presentations.First(t => t.PresentationID == id);
            this.context.Presentations.Remove(entity);
            this.context.SaveChanges();
        }

        public void Update(Presentation item)
        {
            this.context.Presentations.Update(item);
            this.context.SaveChanges();
        }
    }
}