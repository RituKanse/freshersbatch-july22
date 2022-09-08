using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hotel_Management_System.Controllers
{
    public class LoginController : Controller
    {
        UserDataAccess objUser = new UserDataAccess();

        //[HttpGet]
        //public IActionResult RegisterUser()
        //{

        //    return View();
        //}

        //[HttpPost]
        //public IActionResult RegisterUser([Bind] UserDetails user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string RegistrationStatus = objUser.RegisterUser(user);
        //        if (RegistrationStatus == "Success")
        //        {
        //            ModelState.Clear();
        //            TempData["Success"] = "Registration Successful!";
        //            return View();
        //        }
        //        else
        //        {
        //            TempData["Fail"] = "This User ID already exists. Registration Failed.";
        //            return View();
        //        }
        //    }
        //    return View();
        //}

        [HttpGet]
        public IActionResult UserLogin()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserLogin([Bind] UserDetails user,string Role )
        {
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");

            if (ModelState.IsValid)
            {
                string LoginStatus = objUser.ValidateLogin(user);

                if (LoginStatus == "Success"&& Role=="Owner")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserID),
                        new Claim(ClaimTypes.Role, "Owner")
                    };
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Role");
                }
                else if (LoginStatus == "Success" && Role == "Manager")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserID),
                        new Claim(ClaimTypes.Role, "Manager")
                    };
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("ManagerIndex", "Role");
                }
                else if (LoginStatus == "Success" && Role == "Receptionist")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserID),
                        new Claim(ClaimTypes.Role, "Receptionist")
                    };
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("ReceptionistIndex", "Role");
                }
                else
                {
                    TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                    return View();
                }
            }
            else
                return View();

        }
        [HttpPost]
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("UserLogin","Login");
        }
    }
}
