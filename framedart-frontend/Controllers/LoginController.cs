using System.Web.Mvc;

namespace framedart_frontend.Controllers {
    public class LoginController : Controller {

        public ActionResult Index () {
            return View();
        }

        public JsonResult ValidarUsuario (string username, string password) {
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }
    }
}