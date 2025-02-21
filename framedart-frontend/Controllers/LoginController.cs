using framedart_frontend.Models.Login;
using framedart_frontend.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace framedart_frontend.Controllers {
    public class LoginController : Controller {

        private readonly ILoginService _service;

        public LoginController (ILoginService service) {
            _service = service;
        }

        public ActionResult Index () {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> ValidarUsuario (LoginUserDTO user) {

            var response = await _service.Login(user);

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}