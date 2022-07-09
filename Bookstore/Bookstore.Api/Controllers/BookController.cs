using System;
using System.Linq;
using System.Net;
using Bookstore.Models.Models;
using Bookstore.Models.ViewModels;
using Bookstore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Api.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {

        BookRepository _bookRepository = new BookRepository();

        [Route("list")]
        [HttpGet]
        [ProducesResponseType(typeof(ListResponse<BookModel>), (int)HttpStatusCode.OK)]

        public IActionResult GetUsers(int pageIndex = 1, int pageSize = 10, string keyword = "")
        {
            try
            {
                var books = _bookRepository.GetBooks(pageIndex, pageSize, keyword);
                if (books == null)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");

                return StatusCode(HttpStatusCode.OK.GetHashCode(), books);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(BookModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotFoundResult), (int)HttpStatusCode.NotFound)]
        public IActionResult GetUser(int id)
        {
            try
            {
                var book = _bookRepository.GetBook(id);
                if (book == null)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");

                return StatusCode(HttpStatusCode.OK.GetHashCode(), book);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(BookModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult AddBook(BookModel model)
        {
            if (model == null)
                return BadRequest("Model is null");
            Book book = new Book()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Base64image = model.Base64image,
                Categoryid = model.Categoryid,
                Publisherid = model.Publisherid,
                Quantity = model.Quantity,
        };
            var response = _bookRepository.AddBook(book);
            BookModel bookModel = new BookModel(response);

            return Ok(bookModel);
        }

        [Route("update")]
        [HttpPut]
        [ProducesResponseType(typeof(BookModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]

        public IActionResult UpdateBook(BookModel model)
        {
            try
            {
                if (model != null)
                {
                    var book = _bookRepository.GetBook(model.Id);
                    if (book == null)
                        return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Book not found");
                    book.Id = model.Id;
                    book.Name = model.Name;
                    book.Price = model.Price;
                    book.Publisherid = model.Publisherid;
                    book.Categoryid = model.Categoryid;
                    book.Quantity = model.Quantity;
                    book.Description = model.Description;
                    book.Base64image = model.Base64image;



                    var isSaved = _bookRepository.UpdateBook(book);
                    if (isSaved!=null)
                    {
                        return StatusCode(HttpStatusCode.OK.GetHashCode(), "Book detail updated successfully");
                    }
                }

                return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        [Route("delete/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]

        public IActionResult DeleteUser(int id)
        {
            try
            {
                if (id > 0)
                {
                    var book = _bookRepository.GetBook(id);
                    if (book == null)
                        return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Book not found");

                    var isDeleted = _bookRepository.DeleteBook(id);
                    if (isDeleted)
                    {
                        return StatusCode(HttpStatusCode.OK.GetHashCode(), "Book detail deleted successfully");
                    }
                }

                return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "Please provide correct information");
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }
    }
}
