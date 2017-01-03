using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class BookApi
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public string PublishingHouse { get; set; }
        public TypeOfBook TypeOfBook { get; set; }
        public bool GreatDeal { get; set; }
    }

    public enum TypeOfBook
    {
        Audiobook,
        Ebook
    }

    public interface IBookRepository
    {
        BookApi[] GetAllBooks();
        BookApi[] GetBooksByTitle(string title);
        BookApi[] GetBooksByPublishingHouse(string publishinghouse);
        BookApi[] GetBooksByTypeOfBook(string typeofbook);
    }

    public class MemoryBookRepository : IBookRepository
    {
        private List<BookApi> _books = new List<BookApi>();
        public BookApi[] GetAllBooks()
        {
            return _books.ToArray();
        }
        public BookApi[] GetBooksByTitle(string title)
        {
            return _books.ToArray();
        }
        public BookApi[] GetBooksByPublishingHouse(string publishinghouse)
        {
            return _books.ToArray();
        }
        public BookApi[] GetBooksByTypeOfBook(string typeofbook)
        {
            return _books.ToArray();
        }
    }
}