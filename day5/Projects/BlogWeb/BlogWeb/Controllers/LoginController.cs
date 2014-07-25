using BlogWeb.DAO;
using BlogWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace BlogWeb.Controllers
{
    public class LoginController : Controller
    {
        private UsuarioDAO userDAO;

        public LoginController(UsuarioDAO userDAO)
        {
            this.userDAO = userDAO;

            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("blog", "Usuario", "Id", "Login", true);
            }
        }
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(string login, string senha)
        {
            Usuario usuario = userDAO.Busca(login, senha);
            if (WebSecurity.Login(login,senha))
            {
                return RedirectToAction("Index","Post");
            }
            else
            {
                ModelState.AddModelError("login.invalido", "Login ou senha incorreto");
                return View("Index");
            }
        }
	}
}