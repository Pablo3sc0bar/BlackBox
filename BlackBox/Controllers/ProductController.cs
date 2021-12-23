using Arch.EntityFrameworkCore.UnitOfWork;
using BlackBox.Entities.Accounting;
using BlackBox.Entities.Ordering;
using BlackBox.Entities.ProductAdditionals;
using BlackBox.Models.ProductAdditionals;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackBox.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Book(int id)
        {
            if (id != 0)
            {
                var book = _unitOfWork.GetRepository<Book>().GetAll().Where(book => book.ID == id).FirstOrDefault();
                if (book != null)
                {
                    BookModel model;
                    book.Author = _unitOfWork.GetRepository<Author>().GetAll().Where(author => author.ID == book.AuthorId).FirstOrDefault();
                    book.Jenre = _unitOfWork.GetRepository<Jenre>().GetAll().Where(jenre => jenre.ID == book.JenreId).FirstOrDefault();

                    if (User.Identity.IsAuthenticated)
                    {
                        var userAndBooks = _unitOfWork.GetRepository<UsersAndBooks>().GetAll();
                        var currentUser = _unitOfWork.GetRepository<User>().GetAll()
                            .Where(user => user.Email == User.Identity.Name).FirstOrDefault();
                        userAndBooks = userAndBooks.Where(u => u.UserID == currentUser.ID);
                        book.DownloadLink = "";
                        if (userAndBooks.Where(u => u.BookID == book.ID).Any())
                        {
                            model = new BookModel() { Book = book, isBuyed = true };
                        }
                        else
                        {
                            model = new BookModel() { Book = book, isBuyed = false };
                        }
                    }
                    else
                    {
                        book.DownloadLink = "";
                        model = new BookModel() { Book = book, isBuyed = false };
                    }



                    return View(model);
                }
                else
                    return View("404");
            }
            else
                return View("404");

        }

        [HttpGet]
        public IActionResult Author(int id)
        {
            if (id != 0)
            {
                var author = _unitOfWork.GetRepository<Author>().GetAll().Where(author => author.ID == id).FirstOrDefault();
                if (author != null)
                {
                    author.Books = _unitOfWork.GetRepository<Book>().GetAll().Where(book => book.AuthorId == author.ID).AsEnumerable();
                    return View(author);
                }
                else
                    return View("404");
            }
            else
                return View("404");

        }
    }
}
