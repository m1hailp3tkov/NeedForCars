using Microsoft.AspNetCore.Mvc;

namespace NeedForCars.Web.Areas.Administrator.Controllers
{
    public class HomeController : AdministratorController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}