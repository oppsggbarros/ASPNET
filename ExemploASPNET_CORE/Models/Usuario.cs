using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exemplo_3_Endpoint_ASPNET_Banco.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id_usuario")]
        public int Id {get; set;}
        [Column("password")]
        public string Password {get; set;}
        [Column("nome_usuario")]
        public string Nome_usuario {get; set;}
        [Column("ramal")]
        public int Ramal {get; set;}
        [Column("especialidade")]
        public string Especialidade {get; set;}
    }
    

}