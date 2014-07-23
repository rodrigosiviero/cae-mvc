using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Blog
{
    public class ConnectionFactory
    {
        public static IDbConnection CriaConexao()
        {
            var stringConexao = ConfigurationManager.ConnectionStrings["blog"];
            IDbConnection conexao = new SqlConnection();
            conexao.ConnectionString = stringConexao.ConnectionString;
            conexao.Open();
            return conexao;
        }
    }
}
