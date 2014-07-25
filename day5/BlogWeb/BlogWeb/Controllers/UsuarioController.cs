using BlogWeb.DAO;
using BlogWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDAO usuarioDAO;

        public UsuarioController(UsuarioDAO usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;
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
            usuarioDAO.Adiciona(usuario);
            return RedirectToAction("Index");
        }
	}
}