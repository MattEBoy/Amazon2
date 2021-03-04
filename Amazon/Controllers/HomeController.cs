using Amazon.Models;
using Amazon.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBookRepository _repository;
        public int PageSize = 5;
        public HomeController(ILogger<HomeController> logger, IBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int page = 1)
        {

            //Program uses tag helpers to dynamically create the page navigation and displays 5 items per page
            return View(new BookListViewModel
            {
                //superior filter on "like"
                Books = _repository.Books
                    .Where(b => category == null || b.ClassificationCategory.Contains(category)).OrderBy(b => b.BookID).Skip((page - 1) * PageSize).Take(PageSize)
                    ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page
                        ,
                    ItemsPerPage = PageSize
                        ,
                    //superior filter on "like"
                    //Page numbering matches results
                    TotalNumItems = _repository.Books.Where(b => category == null || b.ClassificationCategory.Contains(category)).Count()


                }
                ,
                Category = category
            });
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
    }
}
