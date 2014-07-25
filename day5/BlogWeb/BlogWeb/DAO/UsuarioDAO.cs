using BlogWeb.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogWeb.DAO
{
    public class UsuarioDAO
    {
        private ISession s;

        public UsuarioDAO(ISession session)
        {
            this.s = session;
        }

        public void Adiciona(Usuario usuario)
        {
            ITransaction tx = s.BeginTransaction();
            s.Save(usuario);
            tx.Commit();
        }

        public IList<Usuario> Lista()
        {
            String hql = "select u from Usuario u";
            IQuery query = s.CreateQuery(hql);
            return query.List<Usuario>();
        }

        public Usuario BuscaPorId(int id)
        {
            return s.Get<Usuario>(id);
        }
    }
}