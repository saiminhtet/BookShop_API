using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookShop_API.Models;
using BookShop_API.Models.ViewModels;
using BookShop_API.BusinessLogic;
using System.Web.Hosting;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Http.Headers;

namespace BookShop_API.Controllers
{
    public class BookController : ApiController
    {

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        [Route("api/book/")]
        public IHttpActionResult GetAllBooks()
        {
            IList<BookList> booklist = null;

            booklist = SearchBooks.GetBooklistAll().ToList<BookList>();

            if (booklist.Count == 0)
            {
                return NotFound();
            }
            return Ok(booklist);
        }

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        [Route("api/book/search/{searchquery}")]
        public IHttpActionResult SearchBook(string searchquery)
        {
            IList<BookList> booklist = null;

            booklist = SearchBooks.GetBooklists(searchquery).ToList<BookList>();
            if (booklist.Count == 0)
            {
                return NotFound();
            }
            return Ok(booklist);
        }

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        [Route("api/book/{id}")]
        public IHttpActionResult GetBookbyID(int id)
        {
            Book book = null;
            book = Books_Logic.GetBook(id);

            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        [Route("api/book/addnew/")]
        public IHttpActionResult AddNewBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            else {

                book = Books_Logic.AddNewBook(book.Title,book.CategoryID,book.ISBN,book.Author,book.Stock,book.Price);
                
                return Ok(book);
            }           
        }


        [System.Web.Http.AcceptVerbs("POST")]
        [System.Web.Http.HttpPost]
        [Route("api/book/update")]
        public IHttpActionResult UpdateExistingBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else
            {
                book = Books_Logic.UpdateBooks(book.BookID, book.Title, book.CategoryID, book.ISBN, book.Author, book.Stock, book.Price);
                if (book != null)
                {
                    return Ok(book);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [System.Web.Http.AcceptVerbs("DELETE")]
        [System.Web.Http.HttpDelete]
        [Route("api/book/delete/{id}")]
        public IHttpActionResult DeleteBook(int id)
        {
            if (id<=0)
            {
                return BadRequest("Not a valid id");
            }
            else
            {
                Books_Logic.DeleteBook(id);
                return Ok("Delete Successful");
            }
        }


        [Route("api/book/{isbn}/cover")]
        public HttpResponseMessage GetBookCover(string isbn)
        {
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            String filePath = HostingEnvironment.MapPath("~/images/" + isbn + ".jpg");
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            Image image = Image.FromStream(fileStream);
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            result.Content = new ByteArrayContent(memoryStream.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            fileStream.Close();
            memoryStream.Close();
            return result;
        }

    }
}