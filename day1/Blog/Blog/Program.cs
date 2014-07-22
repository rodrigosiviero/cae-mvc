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
                Console.WriteLine("Id: " + postAtual.Id + " Post Titulo " + postAtual.Titulo);
            }


            using (IDbConnection conexao = ConnectionFactory.CriaConexao())
            {
                Console.WriteLine("Conexao aberta");
            }
            int idBusca = Convert.ToInt32(Console.ReadLine());
            IList<Post> resultado = dao.BuscarPorId(idBusca);
            foreach (var postAtual in resultado)
            {
                Console.WriteLine("Busca");
                Console.WriteLine("Id: " + postAtual.Id + " Post Titulo " + postAtual.Titulo);
                Console.WriteLine("Busca");
            }

            Post Atulizado = new Post();
            Atulizado.Id = 10;
            Atulizado.Titulo = "Atualizado";
            Atulizado.Conteudo = "Atualizado";
            Atulizado.DataPublicacao = DateTime.Now;
            Atulizado.Publicado = true;
            dao.Atualiza(Atulizado);

            Console.WriteLine("Atualizado");
            Console.WriteLine("Id: " + Atulizado.Id + " Post Titulo " + Atulizado.Titulo + "Conteudo " + Atulizado.Conteudo);
            Console.WriteLine("Atualizado");

            Console.ReadLine();
        }
    }
}
