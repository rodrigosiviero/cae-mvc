using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.Models;
using BlogWeb.Models.ViewModels;
using BlogWeb.DAO;

namespace BlogWeb.Controllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/
        [Route("posts",Name="ListaPosts")]
        public ActionResult Index()
        {
            PostDAO dao = new PostDAO();
            IList<Post> ps = dao.Lista();
            ViewBag.Posts = ps;
            return View();
        }
        [Route("novoPost",Name="NovoPost")]
        public ActionResult Form()
        {
            ViewBag.Post = new Post();
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(PostViewModel viewModel)
        {
            Post post = new Post();
            if (viewModel.Publicado && !viewModel.DataPublicacao.HasValue) 
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
                return View("Form", viewModel);
            }
        }

        public ActionResult Remove(int id)
        {
            PostDAO dao = new PostDAO();
            Post post = dao.BuscaPorId(id);
            dao.Deleta(post);
            return RedirectToAction("Index");
        }

        [Route("posts/{id:int}",Name="VisualizaPost")]
        public ActionResult Visualiza(int id)
        {
            PostDAO dao = new PostDAO();
            Post post = dao.BuscaPorId(id);
            PostViewModel viewModel = new PostViewModel(post);
            return View(viewModel);
        }

        public ActionResult Altera(PostViewModel viewModel)
        {
            if (viewModel.Publicado && !viewModel.DataPublicacao.HasValue)
            {
                ModelState.AddModelError("post.Invalido", "Posts publicados precisam de Data");
            }
            if (ModelState.IsValid) 
            { 
                PostDAO dao = new PostDAO();
                TagDAO TagDAO = new TagDAO();
                Post post = viewModel.CriaPost(TagDAO);
                dao.Atualiza(post);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Visualiza", viewModel);
            }
        }
	}
}