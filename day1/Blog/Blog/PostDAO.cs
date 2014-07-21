using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Blog
{
    public class PostDAO
    {
        public void Adiciona(Post post)
        {
            using (IDbConnection conexao = ConnectionFactory.CriaConexao())
            using (IDbCommand command = conexao.CreateCommand())
            {
                command.CommandText = "insert into " + "posts(titulo,conteudo,dataPublicacao,publicado) " +
                    "values (@titulo,@conteudo,@dataPublicacao,@publicado)";
                //Parameters
                IDbDataParameter paramTitulo = command.CreateParameter();
                paramTitulo.ParameterName = "titulo";
                paramTitulo.Value = post.Titulo;
                command.Parameters.Add(paramTitulo);

                IDbDataParameter paramConteudo = command.CreateParameter();
                paramConteudo.ParameterName = "conteudo";
                paramConteudo.Value = post.Conteudo;
                command.Parameters.Add(paramConteudo);

                IDbDataParameter paramDataPublicacao = command.CreateParameter();
                paramDataPublicacao.ParameterName = "dataPublicacao";
                paramDataPublicacao.Value = post.DataPublicacao;
                command.Parameters.Add(paramDataPublicacao);

                IDbDataParameter paramPublicado = command.CreateParameter();
                paramPublicado.ParameterName = "publicado";
                paramPublicado.Value = post.Publicado;
                command.Parameters.Add(paramPublicado);

                command.ExecuteNonQuery();
            }
        }

        public IList<Post> Lista()
        {   
            using (IDbConnection conexao = ConnectionFactory.CriaConexao())
            using (IDbCommand command = conexao.CreateCommand())
            {
                var sql = "select titulo, conteudo, dataPublicacao, publicado from posts";
                command.CommandText = sql;
                IList<Post> posts = new List<Post>();
                IDataReader r = command.ExecuteReader();
                while (r.Read())
                {
                    Post p = new Post();
                    p.Titulo = Convert.ToString(r["titulo"]);
                    p.Conteudo = Convert.ToString(r["conteudo"]);
                    if (!Convert.IsDBNull(r["dataPublicacao"]))
                    {
                        p.DataPublicacao = Convert.ToDateTime(r["dataPublicacao"]);
                    }
                    p.Publicado = Convert.ToBoolean(r["publicado"]);
                    posts.Add(p);
                }
                r.Close();
                return posts;
            }
        }

    }
}
