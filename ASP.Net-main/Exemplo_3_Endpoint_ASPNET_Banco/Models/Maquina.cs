using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exemplo_3_Endpoint_ASPNET_Banco.Models
{
    [Table("maquina")]
    public class Maquina
    {
        [Key]
        [Column("id_maquina")]
        public int Id { get; set; }
        [Column("tipo")]
        public string Tipo { get; set; }
        [Column("velocidade")]
        public int Velocidade { get; set; }
        [Column("harddisk")]
        public int Harddisk { get; set; }
        [Column("placa_rede")]
        public int Placa_rede { get; set; }
        [Column("memoria_ram")]
        public int Memoria_ram { get; set; }

    }
}