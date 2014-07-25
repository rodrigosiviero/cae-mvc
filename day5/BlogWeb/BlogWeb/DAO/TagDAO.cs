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
        private ISession s;
        public TagDAO(ISession session)
        {
            this.s = session;
        }

        public Tag BuscaPorNome(string nome)
        {
                string hql = "select t from Tag t where t.Nome = :nome";
                IQuery query = s.CreateQuery(hql);
                query.SetParameter("nome", nome);
                return query.UniqueResult<Tag>();
        }

        public void Adiciona(Tag tag)
        {
                ITransaction tx = s.BeginTransaction();
                s.Save(tag);
                tx.Commit();
        }

        public IList<Tag> Lista()
        {
            string hql="select t from Tag t";
            IQuery query = s.CreateQuery(hql);
            return query.List<Tag>();
        }
    }
}