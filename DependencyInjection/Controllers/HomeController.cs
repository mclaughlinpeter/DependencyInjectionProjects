using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Models;
using DependencyInjection.Infrastructure;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;

        public HomeController(IRepository repo) => repository = repo;
        
        public ViewResult Index() => View(repository.Products);
    }
}