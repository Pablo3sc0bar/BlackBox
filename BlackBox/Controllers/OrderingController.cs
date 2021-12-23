using Arch.EntityFrameworkCore.UnitOfWork;
using BlackBox.Entities.Accounting;
using BlackBox.Entities.Ordering;
using BlackBox.Entities.ProductAdditionals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BlackBox.Models.Ordering;

namespace BlackBox.Controllers
{
    [Authorize]
    public class OrderingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        #region Orders
        [HttpGet]
        public ActionResult Buy()
        {
            var currentUser = _unitOfWork.GetRepository<User>().GetAll()
                .Where(user => user.Email == User.Identity.Name).FirstOrDefault();
            var usersAndBooksRepo = _unitOfWork.GetRepository<UsersAndBooks>();
            var bookRepo = _unitOfWork.GetRepository<Book>();
            var cart = _unitOfWork.GetRepository<Cart>().GetAll()
                .Where(c => c.User.Email == User.Identity.Name);

            foreach (var cartItem in cart)
            {
                var product = bookRepo.GetAll().Where(p => p.ID == cartItem.BookId).FirstOrDefault();
                var bookAndUserItem = new UsersAndBooks() { User = currentUser, Book = product };
                usersAndBooksRepo.Insert(bookAndUserItem);
            }
            _unitOfWork.SaveChanges();
            ClearCart();
            return RedirectToAction("Profile", "Account");
        }
        #endregion

        #region Cart
        [HttpGet]
        public ActionResult Cart()
        {
            int count = 0;
            double price = 0;
            var products = _unitOfWork.GetRepository<Book>().GetAll();
            var cartItems = _unitOfWork.GetRepository<Cart>().GetAll()
                .Where(cart => cart.User.Email == User.Identity.Name);
            foreach (var item in cartItems)
            {
                item.Book = products.Where(product => product.ID == item.BookId).FirstOrDefault();
                count++;
                price += item.Book.Cost;
            }

            var cartModel = new CartModel() { 
                Count = count,
                Price = price,
                Carts = cartItems
            };
            return View(cartModel);
        }

        [HttpGet]
        public ActionResult AddToCart(int id)
        {
            var currentUser = _unitOfWork.GetRepository<User>().GetAll()
                .Where(user => user.Email == User.Identity.Name).FirstOrDefault();
            var product = _unitOfWork.GetRepository<Book>().GetAll()
                .Where(product => product.ID == id).FirstOrDefault();
            var cart = _unitOfWork.GetRepository<Cart>();
            if (cart.GetAll().Where(cart => cart.User.Email == User.Identity.Name && cart.BookId == id).Any())
            {
                var cartItem = cart.GetAll().Where(cart => cart.User.Email == User.Identity.Name && cart.BookId == id).FirstOrDefault();
                cart.Update(cartItem);
            }
            else
                cart.Insert(new Cart()
                {
                    User = currentUser,
                    UserId = currentUser.ID,
                    Book = product,
                    BookId = product.ID
                });
            _unitOfWork.SaveChanges();
            return RedirectToAction("Cart");
        }


        [HttpGet]
        public ActionResult RemoveCartProduct(int cartId)
        {
            var cart = _unitOfWork.GetRepository<Cart>().GetAll()
                .Where(c => c.Id == cartId).FirstOrDefault();
            _unitOfWork.GetRepository<Cart>().Delete(cart);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Cart");
        }

        [HttpGet]
        public ActionResult ClearCart()
        {
            var cartRepo = _unitOfWork.GetRepository<Cart>();
            var currentCart = cartRepo.GetAll()
                .Where(c => c.User.Email == User.Identity.Name);
            foreach(var item in currentCart)
                cartRepo.Delete(item);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Cart");
        }
        #endregion

    }
}
