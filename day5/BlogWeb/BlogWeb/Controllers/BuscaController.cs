using BlogWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class BuscaController : Controller
    {
        private PostDAO postDAO;

        public BuscaController(PostDAO postDAO)
        {
            this.postDAO = postDAO;
        }
        //
        // GET: /Busca/
        public ActionResult Index()
        {
            return View();
        }
        [Route("Busca/Autor/{nome}", Name = "BuscaAutor")]
        public ActionResult BuscaPorAutor(string nome)
        {
            IList<Post> listaPosts = postDAO.ListaPublicadosAutor(nome);
            return View(listaPosts);
        }

        public ActionResult BuscaPorTag(string nome)
        {
            IList<Post> listaTags = postDAO.BuscaPublicadosPorTag(nome);
            return View(listaTags);
        }
    }
}