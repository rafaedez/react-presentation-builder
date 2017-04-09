using System.Collections.Generic;

namespace PresentationBuilder.WebAPI.Models
{
    public interface IPageRepository
    {
        void Add(Page item);
        IEnumerable<Page> GetAll();
        Page Find(long id);
        void Remove(long id);
        void Update(Page item);
    }
}