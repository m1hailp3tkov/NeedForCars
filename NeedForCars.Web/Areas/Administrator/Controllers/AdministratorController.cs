using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Web.Controllers;

namespace NeedForCars.Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]
    public class AdministratorController : Controller
    {
    }
}