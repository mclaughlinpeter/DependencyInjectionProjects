using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Models;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        public IRepository Repository { get; set; } = new MemoryRepository();
        
        public ViewResult Index() => View(Repository.Products);
    }
}