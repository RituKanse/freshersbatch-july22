using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
        [Authorize(Roles = "Owner")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Owner,Manager")]
        public IActionResult ManagerIndex()
        {
            return View();
        }
        [Authorize(Roles = "Owner,Receptionist")]
        public IActionResult ReceptionistIndex()
        {
            return View();
        }

    }
}
