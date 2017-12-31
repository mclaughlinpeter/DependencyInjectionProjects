using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Models;
using DependencyInjection.Infrastructure;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;

        public HomeController(IRepository repo)
        {
            repository = repo;
        }
        
        public ViewResult Index([FromServices]ProductTotalizer totalizer)
        {
            ViewBag.HomeController = repository.ToString();            
            ViewBag.Totalizer = totalizer.Repository.ToString();
            ViewBag.Total = totalizer.Total;
            return View(repository.Products);
        }
    }
}