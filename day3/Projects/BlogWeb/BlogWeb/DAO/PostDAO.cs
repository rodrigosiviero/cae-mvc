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
        public IList<Post> Lista()
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                string hql = "select p from Post p";
                IQuery query = session.CreateQuery(hql);
                IList<Post> posts = query.List<Post>();
                return posts;
            }
        }

        public void Adiciona(Post post)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                ITransaction tx = session.BeginTransaction();
                session.Save(post);
                tx.Commit();
            }
        }

        public Post BuscaPorId(int numeroId)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                return session.Get<Post>(numeroId);
            }
        }

        public void Atualiza(Post post)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                ITransaction tx = session.BeginTransaction();
                session.Merge(post);
                tx.Commit();
            }
        }

        public void Deleta(Post post)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                ITransaction tx = session.BeginTransaction();
                session.Delete(post);
                tx.Commit();
            }
        }
        
    }
}