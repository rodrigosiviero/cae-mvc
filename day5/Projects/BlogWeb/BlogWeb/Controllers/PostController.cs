using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.Models;
using BlogWeb.Models.ViewModels;
using BlogWeb.DAO;
using BlogWeb.Filters;

namespace BlogWeb.Controllers
{
    [AutorizacaoFilter]
    public class PostController : Controller
    {
        private PostDAO dao;
        private TagDAO TagDAO;
        private UsuarioDAO userDAO;

        public PostController(PostDAO dao, TagDAO TagDAO, UsuarioDAO userDAO)
        {
            this.dao = dao;
            this.TagDAO = TagDAO;
            this.userDAO = userDAO;
        }
        //
        // GET: /Post/
        [Route("posts",Name="ListaPosts")]
        public ActionResult Index()
        {
            //PostDAO dao = new PostDAO();
            IList<Post> ps = dao.Lista();
            ViewBag.Posts = ps;
            return View();
        }
        [Route("novoPost",Name="NovoPost")]
        public ActionResult Form()
        {
            //ViewBag.Post = new Post();
            ViewBag.Usuarios = userDAO.Lista();
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(PostViewModel viewModel)
        {
            if (viewModel.Publicado && !viewModel.DataPublicacao.HasValue) 
            {
                ModelState.AddModelError("post.Invalido", "Posts publicados precisam de Data");
            }
            if (ModelState.IsValid)
            {
                //Chamada DAO
                Post post = viewModel.CriaPost(TagDAO,userDAO);
                dao.Adiciona(post);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Usuarios = userDAO.Lista();
                return View("Form", viewModel);
            }
        }

        public ActionResult Remove(int id)
        {
            Post post = dao.BuscaPorId(id);
            dao.Deleta(post);
            return RedirectToAction("Index");
        }

        [Route("posts/{id:int}",Name="VisualizaPost")]
        public ActionResult Visualiza(int id)
        {
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
                Post post = viewModel.CriaPost(TagDAO,userDAO);
                dao.Atualiza(post);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Visualiza", viewModel);
            }
        }

        public ActionResult Publica(int id)
        {
            Post post = dao.BuscaPorId(id);
            post.Publicado = true;
            post.DataPublicacao = DateTime.Now;
            dao.Atualiza(post);
            return new EmptyResult();
        }
	}
}