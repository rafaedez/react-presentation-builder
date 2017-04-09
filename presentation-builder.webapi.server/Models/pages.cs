using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresentationBuilder.WebAPI.Models
{
    public class Page
    {
        public long PageID { get; set; }
        public long PresentationID { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public string Audio { get; set; }
        public int AudioTime { get; set; }
        public int index {get; set;}
    }
}