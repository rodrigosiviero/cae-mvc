using BlogWeb.DAO;
using BlogWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace BlogWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDAO usuarioDAO;

        public UsuarioController(UsuarioDAO usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;

            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("blog", "Usuario", "Id", "Login", true);
            }
        }
        //
        // GET: /Usuario/
        public ActionResult Usuario()
        {
            return View();
        }

        public ActionResult Index()
        {
            IList<Usuario> usuarios = usuarioDAO.Lista();
            return View(usuarios);
        }

        public ActionResult Adiciona(Usuario usuario)
        {
            try
            {
                usuarioDAO.Adiciona(usuario);
                WebSecurity.CreateAccount(usuario.Login, usuario.Password, false);
                return RedirectToAction("Index");
            }
            catch(MembershipCreateUserException e)
            {
                ModelState.AddModelError("usuario.Invalido", e.Message);
                return View(usuario);
            }
        }
	}
}