using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Dto;
using Vendas.Application.Services;
using Vendas.Domain.Entities;

namespace Vendas.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private readonly AuthService _service;

        public LoginController(AuthService service)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var response = await _service.Autenticar(dto);
            return Ok(response);
        }

        [HttpPost("Registrar")]
        [AllowAnonymous]
        public async Task<IActionResult> Registrar([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
  
             var usuarioCadastrado = await _service.Registrar(usuario);
                
            return CreatedAtAction(nameof(Login), new { email = usuarioCadastrado.Email, nome = usuarioCadastrado.Nome }); 
            
        }

        [HttpGet("Eu")]
        [Authorize]
        public async Task<ActionResult<UsuarioDTO>> ObterUsuarioAutenticado()
        {
            try
            {
                var usuario = await _service.ObterUsuarioAutenticadoAsync();
                return Ok(usuario);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Se o usuário não estiver autenticado (mesmo com [Authorize], pode ser um token inválido)
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                // Para outros erros internos
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}
