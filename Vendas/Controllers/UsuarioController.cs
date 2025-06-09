using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Services;

namespace Vendas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    public class UsuarioController : ControllerBase
    {
        private readonly AuthService _service;

        public UsuarioController(AuthService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            var usuarios = await _service.ListarUsuarios();
            return Ok(usuarios);
        }
    }
}
