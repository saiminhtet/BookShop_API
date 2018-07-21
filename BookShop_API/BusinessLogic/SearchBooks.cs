using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookShop_API.Models;
using BookShop_API.Models.ViewModels;
namespace BookShop_API.BusinessLogic
{
    public class SearchBooks
    {
        public static IQueryable<BookList> GetBooklists(string searchquery)
        {
            var entities = new Bookshop();

            var categoryname = entities.Categories.Where(x => x.Name.Contains(searchquery)).SingleOrDefault();

            // IQueryable<BookList> booklist = entities.Books.Where(b => b.Author == author || b.Title == title || b.CategoryID == category);
            if (categoryname != null)
            {
                IQueryable<BookList> booklist = from a in entities.Books.Where(a => a.Author.Contains(searchquery) || a.Title.Contains(searchquery) || a.ISBN.Contains(searchquery) || a.CategoryID == categoryname.CategoryID)
                                                from b in entities.Categories
                                                where a.CategoryID == b.CategoryID
                                                select new BookList
                                                {
                                                    BookID = a.BookID,
                                                    Author = a.Author,
                                                    CategoryID = a.CategoryID,
                                                    CategoryName = b.Name,
                                                    Title = a.Title,
                                                    ISBN = a.ISBN,
                                                    Price = a.Price,
                                                    Stock = a.Stock
                                                };
                return booklist;
            }
            else
            {
                IQueryable<BookList> booklist = from a in entities.Books.Where(a => a.Author.Contains(searchquery) || a.Title.Contains(searchquery) || a.ISBN.Contains(searchquery))
                                                from b in entities.Categories
                                                where a.CategoryID == b.CategoryID
                                                select new BookList
                                                {
                                                    BookID = a.BookID,
                                                    Author = a.Author,
                                                    CategoryID = a.CategoryID,
                                                    CategoryName = b.Name,
                                                    Title = a.Title,
                                                    ISBN = a.ISBN,
                                                    Price = a.Price,
                                                    Stock = a.Stock
                                                };
                return booklist;
            }
        }

        public static IQueryable<BookList> GetBooklistAll()
        {
            var entities = new Bookshop();
            //IQueryable<Book> booklist = entities.Books;
            IQueryable<BookList> booklist = from a in entities.Books
                                            from b in entities.Categories
                                            where a.CategoryID == b.CategoryID
                                            select new BookList
                                            {
                                                BookID = a.BookID,
                                                Author = a.Author,
                                                CategoryID = a.CategoryID,
                                                CategoryName = b.Name,
                                                Title = a.Title,
                                                ISBN = a.ISBN,
                                                Price = a.Price,
                                                Stock = a.Stock
                                            };

            return booklist;

        }


    }
}