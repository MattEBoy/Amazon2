using Amazon.Infrastructure;
using Amazon.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Category menu is inserted into the view by using a View Component
//View Component partial view created and inserted via the ViewComponent
namespace Amazon.Components
{
    //this view helps out with the filters tab
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
            return View(_repository.Books.Select(b => b.Category).Distinct().OrderBy(c => c));
        }
    }
}
