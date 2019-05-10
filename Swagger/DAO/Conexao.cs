using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Swagger.DAO
{
    public class conexao
    {      
        public MySqlConnection RetornaComponenteConexao()
        {
            var conexaoString = ConfigurationManager.ConnectionStrings["ConexaoBanco"].ConnectionString;
            var conexao = new MySqlConnection(conexaoString);
            return conexao;
        }        
    }
}