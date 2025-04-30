using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEscolarAPI.Models
{
    public class Usuario
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        // role: aluno, professor, coordenador, admin
    }
}