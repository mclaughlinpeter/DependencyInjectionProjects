using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Models;
using DependencyInjection.Infrastructure;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        private ProductTotalizer totalizer;

        public HomeController(IRepository repo, ProductTotalizer total)
        {
            repository = repo;
            totalizer = total;
        }
        
        public ViewResult Index()
        {
            ViewBag.HomeController = repository.ToString();            
            ViewBag.Totalizer = totalizer.Repository.ToString();
            ViewBag.Total = totalizer.Total;
            return View(repository.Products);
        }
    }
}