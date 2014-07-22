using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NHibernate;
namespace Blog
{
    public class PostDAO
    {
        public void Adiciona(Post post)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                ITransaction tx = session.BeginTransaction();
                session.Save(post);
                tx.Commit();
            }
        }

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

        public Post BuscarPorId(int numeroID)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                return session.Get<Post>(numeroID);
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

        public void Delete(Post post)
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
