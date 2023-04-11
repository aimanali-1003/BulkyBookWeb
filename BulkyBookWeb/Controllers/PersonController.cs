using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class PersonController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var persons = new PersonDatabase();
            return View(persons);
        }
    }
}
