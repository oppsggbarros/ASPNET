using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEscolarAPI.DTO
{
    public class DisciplinaAlunoCursoDTO
    {
        public int AlunoID { get; set; }
        public int DisciplinaID { get; set; }
        public int CursoID { get; set; }
        public string Descricao { get; set; }
    }
}