using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Dto;
using Vendas.Application.Services;

namespace Vendas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimentacaoEstoqueController : ControllerBase
    {
        private readonly MovimentacaoEstoqueService _service;
        public MovimentacaoEstoqueController(MovimentacaoEstoqueService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodasMovimentacoesEstoque()
        {
            var movimentacoes = await _service.ObterTodasMovimentacoesEstoque();
            return Ok(movimentacoes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterMovimentacaoEstoquePorId(int id)
        {
            var movimentacao = await _service.ObterMovimentacaoEstoquePorId(id);
            if (movimentacao == null)
            {
                return NotFound();
            }
            return Ok(movimentacao);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarMovimentacaoEstoque([FromBody] MovimentacaoEstoqueDTO movimentacaoDto)
        {
            
            var movimentacao = await _service.CadastrarMovimentacaoEstoque(movimentacaoDto);
            return CreatedAtAction(nameof(ObterMovimentacaoEstoquePorId), new { id = movimentacao.Id }, movimentacao);
        }
    }
}
