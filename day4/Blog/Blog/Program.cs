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
                //Instancia DAO
                PostDAO dao = new PostDAO();
                //Adiciona
                Post post = new Post();
                post.Titulo = "Post do NHibernate";
                post.Conteudo = "Conteudo";
                post.DataPublicacao = DateTime.Now;
                post.Publicado = true;
            
                //Adiciona chamada DAO
                dao.Adiciona(post);
                Console.Clear();
                //Adiciona

                Console.ReadLine();

                //Atualiza
                Post postAtualizado = new Post();
                postAtualizado.Id = 5;
                postAtualizado.Titulo = "Post Atualizado";
                postAtualizado.Conteudo = "Conteudo Atualizado";
                postAtualizado.DataPublicacao = DateTime.Now;
                postAtualizado.Publicado = true;
                //Atualiza chamada DAO
                dao.Atualiza(postAtualizado);        
                //Atualiza

                //Lista Posts
                Console.WriteLine("Listar todos Posts");
                //Lista Chamada DAO
                IList<Post> postsAtual = dao.Lista();
                foreach (var postAtual in postsAtual)
                {
                    Console.WriteLine("ID: " + postAtual.Id + " Titulo: " + postAtual.Titulo);
                }
                //Lista Posts

                //Delete chamada DAO
                dao.Delete(post);
                //Delete 
                Console.ReadLine();
            }
        }
    }
}
