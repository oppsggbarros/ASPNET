using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEscolarAPI.Models
{
    public class Curso
    {
        public int Id { get; set; };
        public string Descricapao { get; set; };

        public ICollection<Aluno> Alunos { get; set; };
        public ICollection<DisciplinaAlunoCurso> Descricao { get; set; };
    }
}