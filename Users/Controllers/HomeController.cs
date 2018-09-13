using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Users.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View(new Dictionary<string, object> { ["Placeholder"] = "Placeholder" });
        }
    }
}
