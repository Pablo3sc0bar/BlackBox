using Arch.EntityFrameworkCore.UnitOfWork;
using BlackBox.Entities.ProductAdditionals;
using BlackBox.Models;
using BlackBox.Models.ProductAdditionals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlackBox.Entities.Ordering;
using BlackBox.Entities.Accounting;

namespace BlackBox.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var books = _unitOfWork.GetRepository<Book>().GetAll().OrderByDescending(book => book.Cost).Take(8);
            var userAndBooks = _unitOfWork.GetRepository<UsersAndBooks>().GetAll();
            List<BookModel> models = new List<BookModel>();
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = _unitOfWork.GetRepository<User>().GetAll()
                    .Where(user => user.Email == User.Identity.Name).FirstOrDefault();
                userAndBooks = userAndBooks.Where(u => u.UserID == currentUser.ID);
                foreach (var item in books)
                {
                    item.DownloadLink = "";
                    if(userAndBooks.Where(u=>u.BookID == item.ID).Any())
                    {
                        models.Add(new BookModel() { Book = item, isBuyed = true });
                    }
                    else
                    {
                        models.Add(new BookModel() { Book = item, isBuyed = false });
                    }
                }
            }
            else
            {
                foreach (var item in books)
                {
                    item.DownloadLink = "";
                    models.Add(new BookModel() { Book = item, isBuyed = false });
                }
            }
            ViewBag.Books = models;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Search(string SearchString)
        {
            ViewBag.SearchText = SearchString;
            var books = _unitOfWork.GetRepository<Book>().GetAll()
                .Where(t => t.Name.Contains(SearchString));
            var userAndBooks = _unitOfWork.GetRepository<UsersAndBooks>().GetAll();
            List<BookModel> models = new List<BookModel>();
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = _unitOfWork.GetRepository<User>().GetAll()
                    .Where(user => user.Email == User.Identity.Name).FirstOrDefault();
                userAndBooks = userAndBooks.Where(u => u.UserID == currentUser.ID);
                foreach (var item in books)
                {
                    item.DownloadLink = "";
                    if (userAndBooks.Where(u => u.BookID == item.ID).Any())
                    {
                        models.Add(new BookModel() { Book = item, isBuyed = true });
                    }
                    else
                    {
                        models.Add(new BookModel() { Book = item, isBuyed = false });
                    }
                }
            }
            else
            {
                foreach (var item in books)
                {
                    item.DownloadLink = "";
                    models.Add(new BookModel() { Book = item, isBuyed = false });
                }
            }

            return View(models);
        }
    }
}
