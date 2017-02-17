namespace Shop.Migrations
{
    using Shop.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shop.Models.BookDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Shop.Models.BookDBContext context)
        {
            var typesofbook = new List<TypeOfBook>
        {
            new TypeOfBook{ID = 1, Name = "Audiobook"},
            new TypeOfBook{ID = 2, Name = "E-book"}
        };
            typesofbook.ForEach(i => context.TypeOfBook.AddOrUpdate(i));
            context.SaveChanges();
            var books = new List<Book>
        {
            new Book{Title = "Sierpem i m³otem", ReleaseDate = DateTime.Parse("2010-02-10"), Price = 20.99M, Author = "Jab³oñski Miros³aw", PublishingHouse = "Level Trading", GreatDeal = true, TypeOfBook = typesofbook.Single(x => x.Name == "E-book")},
            new Book{Title = "Skylark 2: Skylark trzeci",ReleaseDate = DateTime.Parse("2008-02-20"),Price = 15.20M,Author = "E. E. Doc Smith",PublishingHouse = "Fabryka sów",GreatDeal = true, TypeOfBook = typesofbook.Single(x => x.Name == "Audiobook")},
            new Book{Title = "Nieœmiertelny z Wegi. Skylark w kosmosie",ReleaseDate = DateTime.Parse("2012-01-31"),Price = 30.00M,Author = "Kondrad Ptakowski",PublishingHouse = "Sonia Draga",GreatDeal = true, TypeOfBook = typesofbook.Single(x => x.Name == "E-book")},
            new Book{Title = "¯yæ i umrzeæ w nowej Moskwie. Skylark w kosmosie",ReleaseDate = DateTime.Parse("2016-12-31"),Price = 9.99M,Author = "Maciej Musialik",PublishingHouse = "WAB",GreatDeal = false, TypeOfBook = typesofbook.Single(x => x.Name == "Audiobook")},
            new Book{Title = "Kwadratura trójk¹ta. Skylark w kosmosie",ReleaseDate = DateTime.Parse("2016-12-25"),Price = 14.99M,Author = "Czes³aw Biaczyñski",PublishingHouse = "Sonia Draga",GreatDeal = false, TypeOfBook = typesofbook.Single(x => x.Name == "E-book")},
            new Book{Title = "Stara Ziemia. Skylark w kosmosie",ReleaseDate = DateTime.Parse("2016-12-26"),Price = 17.99M,Author = "Czes³aw Biaczyñski",PublishingHouse = "Level Trading",GreatDeal = false, TypeOfBook = typesofbook.Single(x => x.Name == "Audiobook")}
        };
            books.ForEach(i => context.Book.AddOrUpdate(i));
            context.SaveChanges();
            var storages = new List<Storage>
            {
                new Storage {ID = 1, Name = "PenDrive"},
                new Storage {ID = 2, Name = "CD"},
                new Storage {ID = 3, Name = "DVD"}
            };
            storages.ForEach(i => context.Storage.AddOrUpdate(i));
            context.SaveChanges();
        }
    }
}

