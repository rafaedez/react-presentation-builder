using System.Collections.Generic;

namespace PresentationBuilder.WebAPI.Models
{
    public interface IAuthorRepository
    {
        void Add(Author item);
        IEnumerable<Author> GetAll();
        Author Find(long id);
        void Remove(long id);
        void Update(Author item);
    }
}