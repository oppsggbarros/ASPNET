using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Exemplo_2_ASPNET.Models;

namespace Exemplo_2_ASPNET.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private static List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario { Id = 1, Nome = "João", Email = "joao@gmail.com" },
            new Usuario { Id = 2, Nome = "Maria", Email = "maria@gmail.com" },
            new Usuario { Id = 3, Nome = "Pedro", Email = "pedro@gmail.com" }
        };
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return usuarios;
        }
        [HttpPost]
        public Usuario Post([FromBody] Usuario usuario)
        {
            usuarios.Add(usuario);
            return usuario;
        }

        [HttpPut("{id}")]
        public void Put (int id, [FromBody] Usuario usuario)
        {
            var usuarioExistente = usuarios.Where(x => x.Id == id).FirstOrDefault();

            

            if (usuarioExistente != null)
            {
                usuarioExistente.Nome = usuario.Nome;
                usuarioExistente.Email = usuario.Email;
            }
        }
        [HttpDelete]
        public void Delete(int id)
        {
            usuarios.RemoveAll(x => x.Id == id);
            
        }
    }
}