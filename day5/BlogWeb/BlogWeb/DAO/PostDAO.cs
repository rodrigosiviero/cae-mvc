using Blog;
using BlogWeb.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogWeb
{
    public class PostDAO
    {
        private ISession s;

        public PostDAO(ISession session)
        {
            this.s = session;
        }
        public IList<Post> Lista()
        {
            string hql = "select p from Post p";
            IQuery query = s.CreateQuery(hql);
            IList<Post> posts = query.List<Post>();
            return posts;
        }

        public IList<Post> ListaPublicados()
        {
            string hql = "select p from Post p where p.Publicado = true" +
                          " order by p.DataPublicacao desc";
            IQuery query = s.CreateQuery(hql);
            IList<Post> posts = query.List<Post>();
            return posts;
        }

        public IList<Post> ListaPublicadosAutor(string autor)
        {
            string hql = "select p from Post p join p.Autor a where p.Publicado = true and a.Nome = :autor or a.Email = :autor" +
                          " order by p.DataPublicacao desc";
            IQuery query = s.CreateQuery(hql);
            query.SetParameter("autor", autor);
            IList<Post> posts = query.List<Post>();
            return posts;
        }

        public void Adiciona(Post post)
        {
            ITransaction tx = s.BeginTransaction();
            s.Save(post);
            tx.Commit();
        }

        public Post BuscaPorId(int numeroId)
        {
            return s.Get<Post>(numeroId);
        }

        public void Atualiza(Post post)
        {
            ITransaction tx = s.BeginTransaction();
            s.Merge(post);
            tx.Commit();
        }

        public void Deleta(Post post)
        {
            ITransaction tx = s.BeginTransaction();
            s.Delete(post);
            tx.Commit();
        }

        public IList<Post> BuscaPublicadosPorTag(string nome)
        {
            string hql = "select p from Post p join p.Tags t where " +
                "p.Publicado = true and t.Nome = :nome";
            IQuery query = s.CreateQuery(hql);
            query.SetParameter("nome", nome);
            return query.List<Post>();
        }

    }
}