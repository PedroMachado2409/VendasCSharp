using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Dto;
using Vendas.Application.Services;
using Vendas.Domain.Entities;

namespace Vendas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceitaController : ControllerBase
    {
        private readonly ReceitaService receitaService;

        public ReceitaController(ReceitaService receitaService)
        {
            this.receitaService = receitaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodasAsReceitas()
        {
            var receitas = await receitaService.ObterTodasAsReceitas();
            return Ok(receitas);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarReceita([FromBody] ReceitaDTO receitaDto)
        {
           await receitaService.CadastrarReceita(receitaDto);
            return CreatedAtAction(nameof(ObterTodasAsReceitas), new { id = receitaDto.Id }, receitaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> BaixarReceita(int id)
        {
            return await receitaService.BaixarReceita(id) is Receita receita ? Ok(receita) : NotFound();
        }



    }
}
