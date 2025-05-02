using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEscolarAPI.Models
{
    public class DisciplinaAlunoCurso
    {
        public int AlunoID { get; set; }
        public Aluno Aluno { get; set; }

        public int DisciplinaID { get; set; }
        public Disciplina Disciplina { get; set; }

        public int CursoID { get; set; }
        public Curso Curso { get; set; }

        public string Descricao { get; set; }
    }
}