using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NeedForCars.Web.Controllers
{
    [Authorize]
    public abstract class UserController : Controller
    {
    }
}