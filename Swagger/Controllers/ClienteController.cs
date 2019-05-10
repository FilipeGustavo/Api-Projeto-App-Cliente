using Swagger.DAO;
using Swagger.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;

namespace Swagger.Controllers
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        ClienteDAO clienteDAO = new ClienteDAO();

        /// <summary>
        /// Incluir cliente.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>  
        [Route("inserirCliente")]
        [HttpPost]
        public bool inserirCliente([FromBody] Cliente cliente)
        {
            bool res = clienteDAO.inserirCliente(cliente);
            return res;
        }

        /// <summary>
        /// Alterar dados do cliente.
        /// </summary>
        /// <param name="cliente">Dados que deseja alterar</param>
        /// <returns></returns>  
        [Route("alterarCliente")]
        [HttpPut]
        public bool updateCliente(int id, [FromBody] Cliente cliente)
        {
            bool res = clienteDAO.UpdateCliente(id, cliente);
            return res;
        }


        /// <summary>
        /// Retorna Lista de Cliente.
        /// </summary>
        /// <returns></returns>
        [Route("ListarCliente")]
        [HttpGet]
        public List<Cliente> ListarCliente()
        {
            List<Cliente> clienteList = clienteDAO.buscarListaDeClientes();
            //var json = JsonConvert.SerializeObject(clienteList, Formatting.None);
            return clienteList;
        }

        /// <summary>
        /// Seleciona Cliente por ID.
        /// </summary>
        /// <returns></returns>
        [Route("BuscaClientePorId")]
        [HttpGet]
        public Cliente BuscaClientePorId(int id)
         {
            Cliente cliente = clienteDAO.buscarClientePorId(id);
            return cliente;
        }

        /// <summary>
        /// Deletar Cliente
        /// </summary>
        /// <param name="id">Informar ID do cliente que deseja excluir.</param>
        /// <returns></returns>
        /// <remarks>
        /// Exemplo de entrada:
        /// {
        ///     "id": 1
        /// }
        /// </remarks>
        [Route("DeletarCliente")]
        [HttpDelete]
        public bool deletarCliente([FromBody]int id)
        {
            bool res = clienteDAO.DeleteCliente(id);
            return true;
        }

    }
}