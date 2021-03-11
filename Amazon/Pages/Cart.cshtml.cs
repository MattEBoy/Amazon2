using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Infrastructure;
using Amazon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amazon.Pages.Shared
{
    public class CartModel : PageModel
    {
        private IBookRepository repository;
        public CartModel(IBookRepository _repository)
        {
            repository = _repository;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJason<Cart>("cart") ?? new Cart();
        }
        //_ clarifies which url is gets which
        public IActionResult OnPost(long bookId, string _returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookID == bookId);

            Cart = HttpContext.Session.GetJason<Cart>("cart") ?? new Cart();

            Cart.AddItem(book, 1);

            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = _returnUrl });
        }
    }
}
