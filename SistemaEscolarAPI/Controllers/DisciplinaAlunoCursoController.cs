using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaEscolarAPI.Models;
using SistemaEscolarAPI.DB;
using SistemaEscolarAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace SistemaEscolarAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplinaAlunoCurso : ControllerBase
    {
        private readonly AppDbContext _context;

        public DisciplinaAlunoCurso(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisciplinaAlunoCursoDTO>>> Get()
        {
            var disciplinasAlunosCursos = await _context.DisciplinasAlunosCursos.ToListAsync();
            return Ok(disciplinasAlunosCursos.Select(d => new DisciplinaAlunoCursoDTO { Id = d.Id, Descricao = d.Descricao }));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DisciplinaAlunoCursoDTO disciplinaAlunoCursoDTO)
        {
            var disciplinaAlunoCurso = new DisciplinaAlunoCurso { Descricao = disciplinaAlunoCursoDTO.Descricao };
            _context.DisciplinasAlunosCursos.Add(DisciplinaAlunoCurso);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DisciplinaAlunoCursoDTO disciplinaAlunoCursoDTO)
        {
            var disciplinaAlunoCurso = await _context.DisciplinasAlunosCursos.FindAsync(id);
            if (disciplinaAlunoCurso == null) return NotFound("Disciplina não encontrada");

            disciplinaAlunoCurso.Descricao = disciplinaAlunoCursoDTO.Descricao;
            _context.DisciplinasAlunosCursos.Update(disciplinaAlunoCurso);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var disciplinaAlunoCurso = await _context.DisciplinasAlunosCursos.FindAsync(id);
            if (disciplinaAlunoCurso == null) return NotFound("Disciplina não encontrada");

            _context.DisciplinasAlunosCursos.Remove(disciplinaAlunoCurso);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }

}