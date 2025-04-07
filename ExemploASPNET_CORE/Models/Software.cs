using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exemplo_3_Endpoint_ASPNET_Banco.Models
{
    [Table("software")]
    public class Software
    {
        [Key]
        [Column("id_software")]
        public int Id_software { get; set; }
        [Column("produto")]
        public string Produto { get; set; }
        [Column("harddisk")]
        public int Harddisk { get; set; }
        [Column("memoria_ram")]
        public int Memoria_ram { get; set; }

    }
}