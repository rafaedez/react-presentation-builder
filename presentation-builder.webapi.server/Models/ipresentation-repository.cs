using System.Collections.Generic;

namespace PresentationBuilder.WebAPI.Models
{
    public interface IPresentationRepository
    {
        void Add(Presentation item);
        IEnumerable<Presentation> GetAll();
        Presentation Find(long id);
        void Remove(long id);
        void Update(Presentation item);
    }
}