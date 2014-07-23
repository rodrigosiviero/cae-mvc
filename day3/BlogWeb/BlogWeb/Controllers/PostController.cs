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
            return View();
        }

        public ActionResult Adiciona(Post post)
        {
            //Chamada DAO
            PostDAO dao = new PostDAO();
            dao.Adiciona(post);
            return View();
        }
	}
}