using DotNetDeployments.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DotNetDeployments.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}