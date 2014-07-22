using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NHibernate.Cfg;
using NHibernate;
using FluentNHibernate.Cfg;
using System.Reflection;

namespace Blog
{
    public class Program
    {
        static void Main(string[] args)
        {

            using (ISession session = NHibernateHelper.AbreSession())
            {
                Post post = new Post();
                post.Titulo = "Post do NHibernate";
                post.Conteudo = "Conteudo";
                post.DataPublicacao = DateTime.Now;
                post.Publicado = true;

                ITransaction tx = session.BeginTransaction();
                session.Save(post);
                tx.Commit();

                Post postAtualizado = new Post();
                postAtualizado.Id = 6;
                postAtualizado.Titulo = "Post Atualizado";
                postAtualizado.Conteudo = "Conteudo Atualizado";
                postAtualizado.DataPublicacao = DateTime.Now;
                postAtualizado.Publicado = true;

                ITransaction txAtualiza = session.BeginTransaction();
                session.Merge(postAtualizado);
                txAtualiza.Commit();

                Console.WriteLine("Busca por ID");
                Post busca = session.Get<Post>(1);
                Console.Write(busca.Titulo);

                Console.WriteLine("Selecionar todos Posts");
                string hql = "select p from Post p";
                IQuery query = session.CreateQuery(hql);
                IList<Post> posts = query.List<Post>();

                foreach (var postAtual in posts)
                {
                    Console.WriteLine("ID: " + postAtual.Id + " Titulo: " + postAtual.Titulo);
                }

                Console.ReadLine();
            }
        }
    }
}
