namespace Shop.Migrations
{
    using Shop.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shop.Models.BookDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
        protected override void Seed(Shop.Models.BookDBContext context)
        {
            context.Book.AddOrUpdate(i => i.Title,
        new Book
        {
            Title = "Sierpem i m³otem",
            ReleaseDate = DateTime.Parse("2010-02-10"),
            Price = 20.99M,
            Author = "Jab³oñski Miros³aw",
            PublishingHouse = "Level Trading",
            TypeOfBook = TypeOfBook.Audiobook,
            GreatDeal = true
        },

         new Book
         {
             Title = "Skylark 2: Skylark trzeci",
             ReleaseDate = DateTime.Parse("2008-02-20"),
             Price = 15.20M,
             Author = "E. E. Doc Smith",
             PublishingHouse = "Fabryka sów",
             TypeOfBook = TypeOfBook.Audiobook,
             GreatDeal = true
         },

         new Book
         {
             Title = "Nieœmiertelny z Wegi. Skylark w kosmosie",
             ReleaseDate = DateTime.Parse("2012-01-31"),
             Price = 30.00M,
             Author = "Kondrad Ptakowski",
             PublishingHouse = "Sonia Draga",
             TypeOfBook = TypeOfBook.Ebook,
             GreatDeal = true
         },

       new Book
       {
           Title = "¯yæ i umrzeæ w nowej Moskwie. Skylark w kosmosie",
           ReleaseDate = DateTime.Parse("2016-12-31"),
           Price = 9.99M,
           Author = "Maciej Musialik",
           PublishingHouse = "WAB",
           TypeOfBook = TypeOfBook.Ebook,
           GreatDeal = false
       },
       new Book
       {
           Title = "Kwadratura trójk¹ta. Skylark w kosmosie",
           ReleaseDate = DateTime.Parse("2016-12-25"),
           Price = 14.99M,
           Author = "Czes³aw Biaczyñski",
           PublishingHouse = "Sonia Draga",
           TypeOfBook = TypeOfBook.Audiobook,
           GreatDeal = false
       },
       new Book
       {
           Title = "Stara Ziemia. Skylark w kosmosie",
           ReleaseDate = DateTime.Parse("2016-12-26"),
           Price = 17.99M,
           Author = "Czes³aw Biaczyñski",
           PublishingHouse = "Level Trading",
           TypeOfBook = TypeOfBook.Ebook,
           GreatDeal = false
       }
   );
        }
    }
}

