using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Dto;
using Vendas.Application.Services;

namespace Vendas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AtendimentoController : ControllerBase
    {
        private readonly AtendimentoService _atendimentoService;

         public AtendimentoController(AtendimentoService atendimentoService)
        {
            _atendimentoService = atendimentoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterAtendimentos()
        {
            var atendimentos = await _atendimentoService.ObterTodosOsAtendimentosAsync();
            return Ok(atendimentos);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAtendimento([FromBody] AtendimentoDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Dados do atendimento não podem ser nulos.");
            }
            var atendimentoCriado = await _atendimentoService.CriarAtendimentoAsync(dto);
            return CreatedAtAction(nameof(ObterAtendimentos), new { id = atendimentoCriado.Id }, atendimentoCriado);
        }

        [HttpPost("parecer/{id}")]
        public async Task<IActionResult> AdicionarParecer(int id, [FromBody] ParecerDTO parecerDto)
        {
                var atendimentoAtualizado = await _atendimentoService.AdicionarParecer(id, parecerDto);
                return Ok(atendimentoAtualizado);
        }
    }
}
