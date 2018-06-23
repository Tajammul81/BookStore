using BookStore.Models;
using BookStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> Index(string searchString)
        {
            List<Book> allStock = new List<Book>();
            //Session Cookies
            if(Session["Stock"] != null)
            {
                allStock = Session["Stock"] as List<Book>;
            }
            else
            {
                BookstoreService bService = new BookstoreService();
                IEnumerable<Book> allBooks = await bService.GetBooksAsync(searchString);
                allStock = allBooks.ToList();

                Session["Stock"] = allStock;
            }
            
            return View(allStock);
        }

        [HttpPost]
        public ActionResult SearchStore(string searchString)
        {
            //return View();
           return RedirectToAction("Index", new { SearchString = searchString });
        }

        [HttpGet]
        public ActionResult AddToCart(string Title, string Author, int inStock, decimal Price)
        {
            Book thisBook = new Book() { Title = Title, Author = Author, inStock = inStock, Price = Price };
            List<Book> Cart = new List<Book>();

            if (Session["Cart"] != null)
            {
                Cart = Session["Cart"] as List<Book>;
            }

            Cart.Add(thisBook);
            Session["Cart"] = Cart;

            if (Session["Stock"] != null)
            {
                List<Book> allStock = Session["Stock"] as List<Book>;
                Book stockBook = allStock.Where(B => B.Title == Title && B.Author == Author && B.inStock == inStock && B.Price == Price).FirstOrDefault();
                //updating stock
                if(stockBook != null)
                {
                    stockBook.inStock--;
                    Session["Stock"] = allStock;
                }
            }

            return RedirectToAction("Index", new { searchString = "" });
        }
        // On successful page load a book list appears
        /*[HttpGet]
        public JsonResult SearchBooks(string SearchString = "")
        {
            BookstoreService bService = new BookstoreService();

            return new JsonResult { Data = bService.GetBooksAsync(SearchString), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }*/


        public ActionResult ViewCart()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RemoveFromCart(string Title, string Author, int inStock, decimal Price)
        {
            List<Book> cart = new List<Book>();
            // Removing book on View
            if (Session["cart"] != null)
            {
                cart = Session["cart"] as List<Book>;

                Book bookToRemove = cart.Where(B => B.Title == Title && B.Author == Author && B.inStock == inStock && B.Price == Price).FirstOrDefault();

                if(bookToRemove != null)
                {
                    cart.Remove(bookToRemove);
                    Session["cart"] = cart;

                    if (Session["Stock"] != null)
                    {
                        List<Book> allStock = Session["Stock"] as List<Book>;
                        Book stockBook = allStock.Where(B => B.Title == Title && B.Author == Author && B.Price == Price).FirstOrDefault();
                        // If book gets removed from Cart, Stock gets updated
                        if (stockBook != null)
                        {
                            stockBook.inStock++;
                            Session["Stock"] = allStock;
                        }
                    }
                }
            }            

            return RedirectToAction("ViewCart");
        }
    }
}