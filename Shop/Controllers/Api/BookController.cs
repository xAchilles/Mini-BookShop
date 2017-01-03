using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Api.Controllers
{
    public class BookController : ApiController
    {
        private BookDBContext db = new BookDBContext();

        List<Book> books = new List<Book>();

        public IEnumerable<Book> GetAllBooks()
        {
            books = db.Book.OrderBy(x => x.Title).ToList();

            return books;
        }
    }
}
