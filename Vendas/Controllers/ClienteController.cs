using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Services;
using Vendas.Application.Dto;

namespace Vendas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _service;

        public ClienteController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosClientes()
        {
            var clientes = await _service.ObterTodosClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterClientePorId(int id)
        {
            var cliente = await _service.ObterClientePorId(id);
            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarCliente([FromBody] ClienteDTO clienteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var clienteCadastrado = await _service.CadastrarCliente(clienteDto);

            return CreatedAtAction(nameof(ObterClientePorId), new { id = clienteCadastrado.Id }, clienteCadastrado);
        }

        [HttpGet("ativos")]
        public async Task<IActionResult> ObterClientesAtivos()
        {
            var clientesAtivos = await _service.ObterClientesAtivos();
            return Ok(clientesAtivos);
        }
    }
}
