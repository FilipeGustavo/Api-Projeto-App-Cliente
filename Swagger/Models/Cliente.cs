using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Swagger.Models.Cliente
{
    public class Cliente
    {
        [Required]
        public int id_cliente { get; set; }

        public string nome_cliente { get; set; }

        public string cpf { get; set; }

        public string end { get; set; }

        public string bairro { get; set; }

        public string cidade { get; set; }

        public string data_nascimento { get; set; }

        public string email { get; set; }
    }
}