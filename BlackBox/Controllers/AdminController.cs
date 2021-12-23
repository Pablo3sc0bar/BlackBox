using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arch.EntityFrameworkCore.UnitOfWork;
using BlackBox.Entities.ProductAdditionals;
using BlackBox.Entities.Accounting;
using Microsoft.AspNetCore.Authorization;

namespace BlackBox.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Book
        [HttpGet]
        public IActionResult Book()
        {
            var authors = _unitOfWork.GetRepository<Author>().GetAll();
            var jenres = _unitOfWork.GetRepository<Jenre>().GetAll();
            var books = _unitOfWork.GetRepository<Book>().GetAll();
            foreach (var book in books)
            {
                book.Author = authors.Where(author => author.ID == book.AuthorId).FirstOrDefault();
                book.Jenre = jenres.Where(jenre => jenre.ID == book.JenreId).FirstOrDefault();
            }
            return View(books);
        }


        [HttpGet]
        public IActionResult AddBook()
        {
            ViewBag.Jenres = _unitOfWork.GetRepository<Jenre>().GetAll();
            ViewBag.Authors = _unitOfWork.GetRepository<Author>().GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _unitOfWork.GetRepository<Book>().Insert(book);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Book");
        }

        [HttpGet]
        public IActionResult EditBook(int id)
        {
            ViewBag.Jenres = _unitOfWork.GetRepository<Jenre>().GetAll();
            ViewBag.Authors = _unitOfWork.GetRepository<Author>().GetAll();
            var book = _unitOfWork.GetRepository<Book>().GetAll().Where(book => book.ID == id).FirstOrDefault();
            return View(book);
        }

        [HttpPost]
        public IActionResult EditBook(Book book)
        {
            _unitOfWork.GetRepository<Book>().Update(book);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Book");
        }

        [HttpGet]
        public IActionResult DeleteBook(int id)
        {
            var book = _unitOfWork.GetRepository<Book>().GetAll().Where(book => book.ID == id).FirstOrDefault();
            _unitOfWork.GetRepository<Book>().Delete(book);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Book");
        }
        #endregion

        #region Author
        [HttpGet]
        public IActionResult Author()
        {
            var authors = _unitOfWork.GetRepository<Author>().GetAll();
            return View(authors);
        }

        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            _unitOfWork.GetRepository<Author>().Insert(author);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Author");
        }

        [HttpGet]
        public IActionResult EditAuthor(int id)
        {
            var author = _unitOfWork.GetRepository<Author>().GetAll().Where(author => author.ID == id).FirstOrDefault();
            return View(author);
        }

        [HttpPost]
        public IActionResult EditAuthor(Author author)
        {
            _unitOfWork.GetRepository<Author>().Update(author);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Author");
        }

        [HttpGet]
        public IActionResult DeleteAuthor(int id)
        {
            var author = _unitOfWork.GetRepository<Author>().GetAll().Where(author => author.ID == id).FirstOrDefault();
            _unitOfWork.GetRepository<Author>().Delete(author);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Author");
        }
        #endregion

        #region User
        [HttpGet]
        public IActionResult User()
        {
            var users = _unitOfWork.GetRepository<User>().GetAll();
            foreach (var user in users)
            {
                user.Role = _unitOfWork.GetRepository<Role>().GetAll().Where(role => role.ID == user.RoleId).FirstOrDefault();
            }
            return View(users);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            ViewBag.Roles = _unitOfWork.GetRepository<Role>().GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _unitOfWork.GetRepository<User>().Insert(user);
            _unitOfWork.SaveChanges();
            return RedirectToAction("User");
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            ViewBag.Roles = _unitOfWork.GetRepository<Role>().GetAll();
            var user = _unitOfWork.GetRepository<User>().GetAll().Where(user => user.ID == id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public IActionResult EditUser(User user)
        {
            _unitOfWork.GetRepository<User>().Update(user);
            _unitOfWork.SaveChanges();
            return RedirectToAction("User");
        }

        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            var user = _unitOfWork.GetRepository<User>().GetAll().Where(user => user.ID == id).FirstOrDefault();
            _unitOfWork.GetRepository<User>().Delete(user);
            _unitOfWork.SaveChanges();
            return RedirectToAction("User");
        }
        #endregion

        #region Role
        public IActionResult Role()
        {
            var roles = _unitOfWork.GetRepository<Role>().GetAll();
            return View(roles);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            _unitOfWork.GetRepository<Role>().Insert(role);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Role");
        }

        [HttpGet]
        public IActionResult EditRole(int id)
        {
            var role = _unitOfWork.GetRepository<Role>().GetAll()
                .Where(role => role.ID == id).FirstOrDefault();
            return View(role);
        }

        [HttpPost]
        public IActionResult EditRole(Role role)
        {
            _unitOfWork.GetRepository<Role>().Update(role);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Role");
        }

        [HttpGet]
        public IActionResult DeleteRole(int id)
        {
            var role = _unitOfWork.GetRepository<Role>().GetAll()
                .Where(role => role.ID == id).FirstOrDefault();
            _unitOfWork.GetRepository<Role>().Delete(role);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Role");
        }
        #endregion

        #region Jenre
        [HttpGet]
        public IActionResult Jenre()
        {
            var jenres = _unitOfWork.GetRepository<Jenre>().GetAll();
            return View(jenres);
        }

        [HttpGet]
        public IActionResult AddJenre()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddJenre(Jenre jenre)
        {
            _unitOfWork.GetRepository<Jenre>().Insert(jenre);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Jenre");
        }

        [HttpGet]
        public IActionResult EditJenre(int id)
        {
            var jenre = _unitOfWork.GetRepository<Jenre>().GetAll().Where(jenre => jenre.ID == id).FirstOrDefault();
            return View(jenre);
        }

        [HttpPost]
        public IActionResult EditJenre(Jenre jenre)
        {
            _unitOfWork.GetRepository<Jenre>().Update(jenre);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Jenre");
        }

        [HttpGet]
        public IActionResult DeleteJenre(int id)
        {
            var jenre = _unitOfWork.GetRepository<Jenre>().GetAll().Where(jenre => jenre.ID == id).FirstOrDefault();
            _unitOfWork.GetRepository<Jenre>().Delete(jenre);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Jenre");
        }
        #endregion
    }
}
