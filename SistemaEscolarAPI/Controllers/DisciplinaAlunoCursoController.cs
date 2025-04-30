using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaEscolarAPI.Models;
using SistemaEscolarAPI.DB;
using SistemaEscolarAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace SistemaEscolarAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplinaAlunoCursoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DisciplinaAlunoCursoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet] // Método para obter todas as disciplinas
        public async Task<ActionResult<IEnumerable<DisciplinaAlunoCursoDTO>>> Get()
        // async para deixar a opreação assíncrona e não bloquear o thread
        // Task<ActionResult<IEnumerable<DisciplinaAlunoCursoDTO>>> para retornar uma lista de DTOs de disciplinas
        // IEnumerable<DisciplinaAlunoCursoDTO> é uma interface que representa uma coleção de objetos do tipo DisciplinaAlunoCursoDTO
        // ActionResult é uma classe base para resultados de ação em controladores ASP.NET
        {
            var regitros = await _context.DisciplinasAlunosCursos
              .Select(d => new DisciplinaAlunoCursoDTO
              {
                  AlunoID = d.AlunoID,
                  CursoId = d.CursoID,
                  DisciplinaID = d.DisciplinaID,
              })
              .ToListAsync(); // Converte para uma lista assíncrona


            return Ok(regitros); // Retorna a lista de disciplinas com status 200 OK
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DisciplinaAlunoCursoDTO disciplinaAlunoCursoDTO)
        {
            var entidade = new DisciplinaAlunoCurso
            {
                AlunoID = disciplinaAlunoCursoDTO.AlunoID,
                CursoID = disciplinaAlunoCursoDTO.CursoID,
                DisciplinaID = disciplinaAlunoCursoDTO.DisciplinaID
            };
            _context.DisciplinasAlunosCursos.Add(entidade);
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