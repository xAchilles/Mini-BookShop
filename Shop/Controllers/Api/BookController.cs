using Shop.Models;
using Shop.Models.Api;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Api.Controllers
{
    [RoutePrefix("api")]
    public class BookController : ApiController
    {
        private readonly IBookRepository booksRepository;

        public BookController()
        {
            this.booksRepository = new BookRepository(new BookDBContext());
        }
        public BookController(IBookRepository booksRepository)
        {
            this.booksRepository = booksRepository;
        }

        [Route("Book")]
        public IEnumerable<BookDTO> GetAllBooks()
        {
            return booksRepository.GetAllBooks();
        }

        [Route("Book/{search}")]
        public IEnumerable<BookDTO> GetBooksBy(string search)
        {
            return booksRepository.GetBooksBy(search);
        }

        protected override void Dispose(bool disposing)
        {
            booksRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
