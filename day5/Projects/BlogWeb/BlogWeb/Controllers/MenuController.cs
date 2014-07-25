using BlogWeb.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class MenuController : Controller
    {
        private UsuarioDAO userDAO;
        private TagDAO tagDAO;

        public MenuController(UsuarioDAO userDAO, TagDAO tagDAO)
        {
            this.userDAO = userDAO;
            this.tagDAO = tagDAO;
        }
        //
        // GET: /Menu/
        public ActionResult Index()
        {
            ViewBag.Autores = userDAO.Lista();
            ViewBag.Tags = tagDAO.Lista();
            return PartialView();
        }
	}
}