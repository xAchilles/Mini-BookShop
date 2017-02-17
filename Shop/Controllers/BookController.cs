using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class BookController : Controller
    {
        private BookDBContext db = new BookDBContext();
        
        public JsonResult GetAllBooks()
        {
            List<Book> Book = new List<Book>();

            Book = db.Book.OrderBy(a => a.Title).ToList();

            return new JsonResult { Data = Book, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetAudiobooks()
        {
            List<Book> Book = new List<Book>();

            Book = db.Book.OrderBy(a => a.Title).Where(x => x.TypeOfBook.Name == "Audiobook").ToList();

            return new JsonResult { Data = Book, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetEbooks()
        {
            List<Book> Book = new List<Book>();

            Book = db.Book.OrderBy(a => a.Title).Where(x => x.TypeOfBook.Name == "E-book").ToList();

            return new JsonResult { Data = Book, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetNovelties()
        {
            List<Book> Book = new List<Book>();

            DateTime NoveltyDay = new DateTime();
            NoveltyDay = DateTime.Now.AddDays(-14);

            Book = db.Book.OrderBy(a => a.Title).Where(x => (x.ReleaseDate >= NoveltyDay) && (x.ReleaseDate <= DateTime.Now)).ToList();
        
            return new JsonResult { Data = Book, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetPrevues()
        {
            List<Book> Book = new List<Book>();

            DateTime PrevueDay = new DateTime();
            PrevueDay = DateTime.Now.AddDays(14);

            Book = db.Book.OrderBy(a => a.Title).Where(x => (x.ReleaseDate <= PrevueDay) && (x.ReleaseDate >= DateTime.Now)).ToList();

            return new JsonResult { Data = Book, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetGreatDeals()
        {
            List<Book> Book = new List<Book>();

            Book = db.Book.OrderBy(a => a.Title).Where(x => x.GreatDeal == true).ToList();

            return new JsonResult { Data = Book, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetStorage()
        {
            List<Storage> storage = new List<Storage>();

            storage = db.Storage.ToList();

            return new JsonResult { Data = storage, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetSearchedBooks(int routing, string search)
        {
            List<Book> Book = new List<Book>();

            switch (routing)
            {
                case 0:
                    {
                        Book = db.Book.OrderBy(a => a.Title).Where(x => x.Title.Contains(search) || x.Author.Contains(search)).ToList();
                        break;
                    }
                case 1:
                    {
                        Book = db.Book.OrderBy(a => a.Title).Where(x => x.TypeOfBook.Name == "Audiobook" && (x.Title.Contains(search) || x.Author.Contains(search))).ToList(); 
                        break;
                    }
                case 2:
                    {
                        Book = db.Book.OrderBy(a => a.Title).Where(x => x.TypeOfBook.Name == "E-book" && (x.Title.Contains(search) || x.Author.Contains(search))).ToList(); 
                        break;
                    }
                case 3:
                    {
                        DateTime NoveltyDay = new DateTime();
                        NoveltyDay = DateTime.Now.AddDays(-14);

                        Book = db.Book.OrderBy(a => a.Title).Where(x => ((x.ReleaseDate >= NoveltyDay) && (x.ReleaseDate <= DateTime.Now)) && (x.Title.Contains(search) || x.Author.Contains(search))).ToList();
                        break;
                    }
                case 4:
                    {
                        DateTime PrevueDay = new DateTime();
                        PrevueDay = DateTime.Now.AddDays(14);

                        Book = db.Book.OrderBy(a => a.Title).Where(x => ((x.ReleaseDate <= PrevueDay) && (x.ReleaseDate >= DateTime.Now)) && (x.Title.Contains(search) || x.Author.Contains(search))).ToList();
                        break;
                    }
                case 5:
                    {
                        Book = db.Book.OrderBy(a => a.Title).Where(x => x.GreatDeal == true && (x.Title.Contains(search) || x.Author.Contains(search))).ToList(); 
                        break;
                    }
            }
            return new JsonResult { Data = Book, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
