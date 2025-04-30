using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaEscolarAPI.Models;
using SistemaEscolarAPI.DTO;
using SistemaEscolarAPI.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace SistemaEscolarAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CursoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CursoDTO>>> Get()
        // async para deixar a opreação assíncrona e não bloquear o thread
        // Task<ActionResult<IEnumerable<CursoDTO>>> para retornar uma lista de DTOs de cursos
        // IEnumerable<CursoDTO> é uma interface que representa uma coleção de objetos do tipo CursoDTO
        // ActionResult é uma classe base para resultados de ação em controladores ASP.NET
        {
            var cursos = await _context.Cursos
                .Select(cursos => new CursoDTO { Descricao = cursos.Descricao }) // Seleciona os cursos e projeta em um DTO
                .ToListAsync(); // Converte para uma lista assíncrona

            return Ok(cursos); // Retorna a lista de cursos com status 200 OK
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CursoDTO cursoDTO)
        {
            var curso = new Curso { Descricao = cursoDTO.Descricao };
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CursoDTO cursoDTO)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null) return NotFound("Curso não encontrado");

            curso.Descricao = cursoDTO.Descricao;
            _context.Cursos.Update(curso);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null) return NotFound("Curso não encontrado");

            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}