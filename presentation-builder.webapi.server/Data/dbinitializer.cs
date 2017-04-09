using PresentationBuilder.WebAPI.Models;
using PresentationBuilder.WebAPI.Data;
using System;
using System.Linq;

namespace PresentationBuilder.WebAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PresentationContext context)
        {
            context.Database.EnsureCreated();

            if (context.Presentations.Any())
            {
                return;
            }

            var authors = new Author[]
            {
                new Author{AuthorID=1,Name="Dog",Email="Dog@dogdogdog.com",},
            };
            foreach (Author c in authors)
            {
                context.Authors.Add(c);
            }
            context.SaveChanges();

            var presentations = new Presentation[]
            {
                new Presentation{PresentationID=1,AuthorID=1,Name="Dogs", Description="Dogs Presentation",Date=DateTime.Parse("2005-09-01")},
            };
            foreach (Presentation p in presentations)
            {
                context.Presentations.Add(p);
            }
            context.SaveChanges();

            var pages = new Page[]
            {
                new Page{PageID=1,PresentationID=1,Image="1.jpg"},
                new Page{PageID=2,PresentationID=1,Image="2.jpg"}, 
                new Page{PageID=3,PresentationID=1,Image="3.jpg"},
                new Page{PageID=4,PresentationID=1,Image="4.jpg"}, 
                new Page{PageID=5,PresentationID=1,Image="5.jpg"},
                new Page{PageID=6,PresentationID=1,Image="6.jpg"}, 
                new Page{PageID=7,PresentationID=1,Image="7.jpg"},
            };
            foreach (Page p in pages)
            {
                context.Pages.Add(p);
            }
            context.SaveChanges();
        }
    }
}