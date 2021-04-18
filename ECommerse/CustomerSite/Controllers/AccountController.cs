using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSite.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(){
            return Challenge(new AuthenticationProperties  { RedirectUri = "/" }, "oidc");
        }
        public IActionResult Logout(){
            return SignOut(new AuthenticationProperties  { RedirectUri = "/" }, "Cookies","oidc");
        }
        [Authorize]
        public ActionResult MyProfile(){
            return View();
        }
    }
}