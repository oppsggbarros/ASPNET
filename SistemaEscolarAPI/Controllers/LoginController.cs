using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SistemaEscolarAPI.DTO;
using SistemaEscolarAPI.Models;
// using SistemaEscolarAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SistemaEscolarAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login ([FromBody] LoginDTO LoginDTO)
        {
            if (string.IsNullOrWhiteSpace(LoginDTO.Username) || string.IsNullOrWhiteSpace(LoginDTO.Password)) {
                return BadRequest("Username and password are required.");
            }

            var users = new List<Usuario>
            {
                new Usuario { Username = "Administrador", Password = "123", Role = "Administrador" },
                new Usuario { Username = "func", Password = "123", Role = "Funcionario" }
            };

            var user = users.FirstOrDefault( u => 
            u.Username == LoginDTO.Username && 
            u.Password == LoginDTO.Password);

            if (user == null) {
                return Unauthorized(new { message = "Usuario ou Senha invalido"});}

            var token = TokenService.GenerateToken(user);
            return Ok(new {token});
        }
    }
}