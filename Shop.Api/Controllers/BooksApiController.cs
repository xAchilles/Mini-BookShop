using Shop.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Api.Controllers
{
    public class BooksApiController : ApiController
    {
        private readonly IBookRepository _bookRepository;

        public BooksApiController(IBookRepository booksRepository)
        {
            _bookRepository = booksRepository;
        }

        public BookApi[] GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }
        public BookApi[] GetBooksByTitle(string title)
        {
            return _bookRepository.GetBooksByTitle(title);
        }
        public BookApi[] GetBooksByPublishingHouse(string publishinghouse)
        {
            return _bookRepository.GetBooksByPublishingHouse(publishinghouse);
        }
        public BookApi[] GetBooksByTypeOfBook(string typeofbook)
        {
            return _bookRepository.GetBooksByTypeOfBook(typeofbook);
        }
    }
}
