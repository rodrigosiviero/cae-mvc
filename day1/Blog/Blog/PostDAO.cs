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
                var sql = "select id, titulo, conteudo, dataPublicacao, publicado from posts";
                command.CommandText = sql;
                IList<Post> posts = new List<Post>();
                IDataReader r = command.ExecuteReader();
                while (r.Read())
                {
                    Post p = new Post();
                    p.Id = Convert.ToInt32(r["id"]);
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

        public IList<Post> BuscarPorId(int numeroID)
        {
            using (IDbConnection conexao = ConnectionFactory.CriaConexao())
            using (IDbCommand command = conexao.CreateCommand())
            {
                var sql = "select id, titulo, conteudo, dataPublicacao, publicado from posts where id=@id";
                command.CommandText = sql;
                IList<Post> posts = new List<Post>();

                //Parametro
                IDbDataParameter paramId = command.CreateParameter();
                paramId.ParameterName = "id";
                paramId.Value = numeroID;
                command.Parameters.Add(paramId);

                IDataReader r = command.ExecuteReader();

                while (r.Read())
                {
                    Post p = new Post();
                    p.Id = Convert.ToInt32(r["id"]);
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

        public IList<Post> Atualiza(Post post)
        {
            using (IDbConnection con = ConnectionFactory.CriaConexao())
            using (IDbCommand com = con.CreateCommand())
            {
                string sql = "update posts SET titulo=@titulo, conteudo=@conteudo, dataPublicacao=@dataPublicacao, publicado=@publicado " +
                             "where id=@id";

                com.CommandText = sql;
                IList<Post> posts = new List<Post>();

                IDbDataParameter paramId = com.CreateParameter();
                paramId.ParameterName = "id";
                paramId.Value = post.Id;
                com.Parameters.Add(paramId);

                IDbDataParameter paramTitulo = com.CreateParameter();
                paramTitulo.ParameterName = "titulo";
                paramTitulo.Value = post.Titulo;
                com.Parameters.Add(paramTitulo);

                IDbDataParameter paramConteudo = com.CreateParameter();
                paramConteudo.ParameterName = "conteudo";
                paramConteudo.Value = post.Conteudo;
                com.Parameters.Add(paramConteudo);

                IDbDataParameter paramDataPublicacao = com.CreateParameter();
                paramDataPublicacao.ParameterName = "dataPublicacao";
                paramDataPublicacao.Value = post.DataPublicacao;
                com.Parameters.Add(paramDataPublicacao);

                IDbDataParameter paramPublicado = com.CreateParameter();
                paramPublicado.ParameterName = "publicado";
                paramPublicado.Value = post.Publicado;
                com.Parameters.Add(paramPublicado);

                IDataReader r = com.ExecuteReader();

                while (r.Read())
                {
                    post.Titulo = Convert.ToString(r["titulo"]);
                    post.Conteudo = Convert.ToString(r["conteudo"]);
                    if (!Convert.IsDBNull(r["dataPublicacao"]))
                    {
                        post.DataPublicacao = Convert.ToDateTime(r["dataPublicacao"]);
                    }
                    post.Publicado = Convert.ToBoolean(r["publicado"]);
                }
                r.Close();
                return posts;
            }
        }

    }
}
