using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exemplo_ASPNET_EndPoint.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("email")]
        public string Email { get; set; }
    }
}