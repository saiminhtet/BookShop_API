using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookShop_API.Models;
using BookShop_API.Models.ViewModels;

namespace BookShop_API.BusinessLogic
{
    public class Books_Logic
    {
        public static Book GetBook(int id)
        {
            using(Bookshop entities = new Bookshop())
            {
                Book book = entities.Books.Where(b => b.BookID == id).FirstOrDefault<Book>();

                return book;
            }
        }


        public static Book AddNewBook(string title, int catid, string isbn, string author, int stock, decimal price)
        {
            using (Bookshop entities = new Bookshop())
            {
                Book book = new Book()
                {
                    Title = title,
                    CategoryID = catid,
                    ISBN = isbn,
                    Author = author,
                    Stock = stock,
                    Price = price,
                };
                entities.Books.Add(book);
                entities.SaveChanges();
                
                return book;
            }
        }


        public static Book UpdateBooks(int bookid, string title, int catid, string isbn, string author, int stock, decimal price)
        {
            using (Bookshop entities = new Bookshop())
            {
                Book book = entities.Books.Where(p => p.BookID == bookid).First<Book>();
                book.Title = title;
                book.ISBN = isbn;
                book.CategoryID = catid;
                book.Author = author;
                book.Stock = stock;
                book.Price = price;
                entities.SaveChanges();

                return book;
            }
        }

        public static void DeleteBook(int bookid)
        {
            using (Bookshop entities = new Bookshop())
            {
                Book book = entities.Books.Where(p => p.BookID == bookid).First<Book>();
                entities.Books.Remove(book);
                entities.SaveChanges();
            }
        }

    }
}