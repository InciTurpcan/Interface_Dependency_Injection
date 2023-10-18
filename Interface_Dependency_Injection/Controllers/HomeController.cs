using Interface_Dependency_Injection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Interface_Dependency_Injection.Controllers
{
	public class HomeController : Controller
	{
		


		private IProductRepository repository;
        public HomeController(IProductRepository repository)
        {
			this.repository = repository;		
        }
        public IActionResult Index()
		{
			return View(repository.GetAllProducts());
		}

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Product product)
        {
            return RedirectToAction("Index", repository.Add(product));
        }
        public IActionResult Update(int id)
        {
            return View(repository.GetProduct(id));
        }

        [HttpPost]
        public IActionResult Update(Product prd)
        {
            return RedirectToAction("Index", repository.Update(prd));
        }


        public IActionResult Details(int id)
        {
            return View(repository.GetProduct(id));
        }


        public IActionResult Delete(int id)
        {
            return RedirectToAction("Index", repository.Delete(id));
        }

	
	}
}