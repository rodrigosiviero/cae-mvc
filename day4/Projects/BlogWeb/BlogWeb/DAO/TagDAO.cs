using Blog;
using BlogWeb.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogWeb.DAO
{
    public class TagDAO
    {
        public Tag BuscaPorNome(string nome)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                string hql = "select t from Tag t where t.Nome = :nome";
                IQuery query = session.CreateQuery(hql);
                query.SetParameter("nome", nome);
                return query.UniqueResult<Tag>();
            }
        }

        public void Adiciona(Tag tag)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                ITransaction tx = session.BeginTransaction();
                session.Save(tag);
                tx.Commit();
            }
        }
    }
}