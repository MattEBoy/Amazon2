using Amazon.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {

        private IBookRepository _repository;
  
        public NavigationMenuViewComponent(IBookRepository repo)
        {
            _repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_repository.Books.Select(b => b.ClassificationCategory).Distinct().OrderBy(c => c));
        }
    }
}
