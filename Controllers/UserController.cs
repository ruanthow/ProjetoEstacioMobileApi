using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using ProjetoEstacio.DTOs;
using ProjetoEstacio.Model;
using ProjetoEstacio.Services;

namespace ProjetoEstacio.Controllers
{
    [Route("api/[controller]")]
    
    public class UserController : ControllerBase
    {   
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        
        
        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var result = await _userService.GetUsersAsync();
                if (result == null || result.Count < 1)
                {
                    return NotFound("Nenhum usuário cadastrado.");
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("get-user/{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            try
            {
                var result = await _userService.GetUserByIdAsync(id);
                if (result == null)
                {
                    return NotFound("Nenhum usuário cadastrado.");
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Dados do usuário não podem ser nulos.");
                }
                await _userService.SaveUser(user);
                return CreatedAtAction(nameof(GetUser), new { id = user.Name }, "Usuário criado com sucesso.");
            }
            catch (CustomException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Mensagem = ex.ErrorMessage, Erro = ex.ErrorCode });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            try
            {
                if (login == null)
                {
                    return BadRequest("Login ou senha esta incorreto.");
                }
                var result = await _userService.Login(login);
                if (result == null)
                {
                    return BadRequest("Login ou senha incorreto.");
                }
                return Ok(result);
                
            }
            catch (CustomException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Mensagem = ex.ErrorMessage, Erro = ex.ErrorCode });
            }
        }
    }
}
