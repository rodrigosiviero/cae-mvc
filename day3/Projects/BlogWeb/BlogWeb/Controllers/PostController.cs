using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.Models;

namespace BlogWeb.Controllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/
        public ActionResult Index()
        {
            PostDAO dao = new PostDAO();
            IList<Post> ps = dao.Lista();
            ViewBag.Posts = ps;
            return View();
        }

        public ActionResult Form()
        {
            ViewBag.Post = new Post();
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Post post)
        {
            if (post.Publicado && !post.DataPublicacao.HasValue) 
            {
                ModelState.AddModelError("post.Invalido", "Posts publicados precisam de Data");
            }
            if (ModelState.IsValid)
            {
                //Chamada DAO
                PostDAO dao = new PostDAO();
                dao.Adiciona(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", post);
            }
        }

        public ActionResult Remove(int id)
        {
            PostDAO dao = new PostDAO();
            Post post = dao.BuscaPorId(id);
            dao.Deleta(post);
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            PostDAO dao = new PostDAO();
            Post post = dao.BuscaPorId(id);
            return View(post);
        }

        public ActionResult Altera(Post post)
        {
            if (post.Publicado && !post.DataPublicacao.HasValue)
            {
                ModelState.AddModelError("post.Invalido", "Posts publicados precisam de Data");
            }
            if (ModelState.IsValid) 
            { 
                PostDAO dao = new PostDAO();
                dao.Atualiza(post);
                return RedirectToAction("Index");
            }
            else
            {
               return RedirectToAction("Form", post);
            }
        }
	}
}