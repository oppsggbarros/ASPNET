using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaEscolarAPI.Models;
using SistemaEscolarAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SistemaEscolarAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlunoController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoDTO>>> Get()
        {
            var alunos = await _context.Alunos.Include(a => a.Turma)
                .Select(alunos => new AlunoDTO { Nome = alunos.Nome, Curso = alunos.Curso })
                    .ToListAsync();
            return Ok(alunos);

        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AlunoDTO alunoDTO)
        {
            var Curso = await _context.Curso.FistOrDefaultAsync(c => c.Descricao == alunoDTO.Curso);
            if (Curso == null) return BadRequest("Curso não encontrado");

            var aluno = new Aluno { Nome = alunoDTO.Nome, CursoId = Curso.Id };
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AlunoDTO alunoDTO)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return NotFound("Aluno não encontrado");
            var Curso = await _context.Cursos.FistOrDefaultAsync(c => c.Descricao == alunoDTO.Curso);
            if (Curso == null) return BadRequest("Curso não encontrado");

            aluno.Nome = alunoDTO.Nome;

            aluno.CursoId = Curso.ID;
            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return NotFound("Aluno não encontrado");

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
