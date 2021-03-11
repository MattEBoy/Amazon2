using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Infrastructure;
using Amazon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//this is the cart class.
namespace Amazon.Pages.Shared
{
    public class CartModel : PageModel
    {
        private IBookRepository repository;
        public CartModel(IBookRepository _repository, Cart _cart)
        {
            repository = _repository;
            Cart = _cart;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJason<Cart>("cart") ?? new Cart();
        }
        //_ clarifies which url is gets which
        public IActionResult OnPost(long bookId, string _returnUrl, string type)
        {
            //I created this before i read the chapter bbut, hey it works in it's own way
            if (type == "add")
            {
                Book book = repository.Books.FirstOrDefault(b => b.BookID == bookId);

                Cart.AddItem(book, 1);

                HttpContext.Session.SetJson("cart", Cart);
            }
            //my delete function is here
            else if (type == "delete")
            {
                //this method deletes the item from the cart
                Book book = repository.Books.FirstOrDefault(b => b.BookID == bookId);
                if (book != null)
                {
                    Cart.RemoveLine(book);
                    HttpContext.Session.SetJson("cart", Cart);
                }
            }
            //my clear function is here
            else if (type == "clear")
            {
                //this method removes all items from the cart
                
                Cart.Clear();
                HttpContext.Session.SetJson("cart", Cart);
            }




            Console.WriteLine(Cart.ComputeCartTotal().ToString());

            return RedirectToPage(new { returnUrl = _returnUrl });
        }
    }
}
