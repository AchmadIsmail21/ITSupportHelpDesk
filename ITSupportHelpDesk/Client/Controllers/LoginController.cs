using API.ViewModel;
using Client.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class LoginController : Controller
    {
        UserRepository userRepository;
        StaffRepository staffRepository;
        public LoginController(UserRepository userRepository) {
            this.userRepository = userRepository;
            
        }
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Auth(LoginVM login) {
            /*LoginVM loginVM = new LoginVM();
            loginVM.Email = email;
            loginVM.Password = password;*/
            var jwToken = await userRepository.Auth(login);
            var user = await userRepository.GetUserByEmail(login.Email);
            
            if (jwToken == null && user == null) {
                return RedirectToAction("Index", "Login");
            }
            HttpContext.Session.SetString("JWToken", jwToken.Token);
            HttpContext.Session.SetString("UserId", user.UserId.ToString());
            HttpContext.Session.SetString("Email", user.Email);
            HttpContext.Session.SetString("Role", user.Role);
            HttpContext.Session.SetString("RoleId", user.RoleId.ToString());
            HttpContext.Session.SetString("Name", user.Name);
            

            return RedirectToAction("Index", "DashBoard");
        }
       /* [HttpGet("Logout/")]
        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }*/
    }
}
