using Dapper;
using MySql.Data.MySqlClient;
using Swagger.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Swagger.DAO
{
    public class ClienteDAO
    {
        public Boolean inserirCliente(Cliente cliente)
        {
            try
            {
                conexao con = new conexao();

                MySqlConnection facConexao = con.RetornaComponenteConexao();

                string sql = "INSERT INTO CLIENTE" +
                               "(  NOME_CLIENTE" +
                                ", CPF" +
                                ", END" +
                                ", BAIRRO" +
                                ", CIDADE" +
                                ", DATA_NASCIMENTO" +
                                ", EMAIL)" +
                            "VALUES" +
                                "( @NOME_CLIENTE" +
                                ", @CPF" +
                                ", @END" +
                                ", @BAIRRO" +
                                ", @CIDADE" +
                                ", @DATA_NASCIMENTO" +
                                ", @EMAIL)";

                MySqlCommand myComando = new MySqlCommand(sql, facConexao);

                myComando.Parameters.AddWithValue("@NOME_CLIENTE", cliente.nome_cliente);
                myComando.Parameters.AddWithValue("@CPF", cliente.cpf);
                myComando.Parameters.AddWithValue("@END", cliente.end);
                myComando.Parameters.AddWithValue("@BAIRRO", cliente.bairro);
                myComando.Parameters.AddWithValue("@CIDADE", cliente.cidade);
                myComando.Parameters.AddWithValue("@DATA_NASCIMENTO", cliente.data_nascimento);
                myComando.Parameters.AddWithValue("@EMAIL", cliente.email);

                facConexao.Open();

                myComando.ExecuteNonQuery();

                if (facConexao.State == System.Data.ConnectionState.Open)
                {
                    facConexao.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir cliente" + ex);
            }
        }

        public bool UpdateCliente(int id, Cliente cliente)
        {
            try
            {
                conexao con = new conexao();

                MySqlConnection facConexao = con.RetornaComponenteConexao();

                string sql = "UPDATE CLIENTE SET" +
                               "   NOME_CLIENTE = @NOME_CLIENTE" +
                                ", CPF = @CPF" +
                                ", END = @END" +
                                ", BAIRRO = @BAIRRO" +
                                ", CIDADE = @CIDADE" +
                                ", DATA_NASCIMENTO = @DATA_NASCIMENTO" +
                                ", EMAIL = @EMAIL" +
                                "  WHERE ID_CLIENTE = @ID_CLIENTE";

                MySqlCommand myComando = new MySqlCommand(sql, facConexao);

                myComando.Parameters.AddWithValue("@ID_CLIENTE", id);
                myComando.Parameters.AddWithValue("@NOME_CLIENTE", cliente.nome_cliente);
                myComando.Parameters.AddWithValue("@CPF", cliente.cpf);
                myComando.Parameters.AddWithValue("@END", cliente.end);
                myComando.Parameters.AddWithValue("@BAIRRO", cliente.bairro);
                myComando.Parameters.AddWithValue("@CIDADE", cliente.cidade);
                myComando.Parameters.AddWithValue("@DATA_NASCIMENTO", cliente.data_nascimento);
                myComando.Parameters.AddWithValue("@EMAIL", cliente.email);

                facConexao.Open();

               myComando.ExecuteNonQuery();                

                if (facConexao.State == System.Data.ConnectionState.Open)
                {
                    facConexao.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir cliente" + ex);
            }
        }

        public List<Cliente> buscarListaDeClientes()
        {
            try
            {
                conexao con = new conexao();

                MySqlConnection facConexao = con.RetornaComponenteConexao();

                string sql = "SELECT * FROM CLIENTE";

                MySqlCommand myComando = new MySqlCommand(sql, facConexao);

                List<Cliente> list = facConexao.Query<Cliente>(sql).ToList();

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar lista de clientes" + ex);
            }
        }

        public Cliente buscarClientePorId(int id)
        {
            try
            {
                conexao con = new conexao();

                MySqlConnection facConexao = con.RetornaComponenteConexao();

                string sql = "SELECT * FROM CLIENTE WHERE ID_CLIENTE = @ID_CLIENTE";

                MySqlCommand myComando = new MySqlCommand(sql, facConexao);                

                Cliente  cliente = facConexao.QueryFirstOrDefault<Cliente>(sql, new { ID_CLIENTE = id });

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar lista de clientes" + ex);
            }
        }

        public Boolean DeleteCliente(int id)
        {
            try
            {
                conexao con = new conexao();

                MySqlConnection facConexao = con.RetornaComponenteConexao();

                string sql = "DELETE FROM CLIENTE WHERE ID_CLIENTE = @ID_CLIENTE";

                MySqlCommand myComando = new MySqlCommand(sql, facConexao);

                myComando.Parameters.AddWithValue("@ID_CLIENTE", id);

                facConexao.Open();
                myComando.ExecuteNonQuery();

                if(facConexao.State == System.Data.ConnectionState.Open)
                {
                    facConexao.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar cliente" + ex);
            }
        }
    }
}