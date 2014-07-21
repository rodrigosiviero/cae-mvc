using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            Post post = new Post()
            {
                Titulo = "Meu Primeiro Post",
                Conteudo = "Conteudo do Post",
                DataPublicacao = DateTime.Now,
                Publicado = true
            };

            PostDAO dao = new PostDAO();
            dao.Adiciona(post);
            IList<Post> posts = dao.Lista();
            foreach (var postAtual in posts)
            {
                Console.WriteLine("Post Titulo " + postAtual.Titulo);
            }


            using (IDbConnection conexao = ConnectionFactory.CriaConexao())
            {
                Console.WriteLine("Conexao aberta");
            }

        }
    }
}
