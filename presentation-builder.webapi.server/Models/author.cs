using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresentationBuilder.WebAPI.Models
{
    public class Author
    {
        public long AuthorID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}