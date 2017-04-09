using System;
using System.Collections.Generic;
using System.Linq;
using PresentationBuilder.WebAPI.Data;

namespace PresentationBuilder.WebAPI.Models
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly PresentationContext context;

        public AuthorRepository(PresentationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Author> GetAll()
        {
            return this.context.Authors.ToList();
        }

        public void Add(Author item)
        {
            this.context.Authors.Add(item);
            this.context.SaveChanges();
        }

        public Author Find(long id)
        {
            return this.context.Authors.FirstOrDefault(t => t.AuthorID == id);
        }

        public void Remove(long id)
        {
            var entity = this.context.Authors.First(t => t.AuthorID == id);
            this.context.Authors.Remove(entity);
            this.context.SaveChanges();
        }

        public void Update(Author item)
        {
            this.context.Authors.Update(item);
            this.context.SaveChanges();
        }
    }
}