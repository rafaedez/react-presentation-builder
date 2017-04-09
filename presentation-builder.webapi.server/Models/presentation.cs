using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace PresentationBuilder.WebAPI.Models
{
    public class Presentation
    {
        public long PresentationID { get; set; }
        public long AuthorID { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Page> Pages { get; set; }
    }
}