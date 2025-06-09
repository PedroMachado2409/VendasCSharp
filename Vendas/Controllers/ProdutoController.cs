using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Dto;
using Vendas.Application.Services;
using Vendas.Domain.Entities;

namespace Vendas.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService service;
        public ProdutoController(ProdutoService produtoService)
        {
            service = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarProdutos()
        {
            var produtos = await service.ListarTodosOsProdutos();

            if (produtos == null)
                return NotFound("Nenhum produto cadastrado.");

            return Ok(produtos);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarProduto([FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var produtoDto = await service.CadastrarProdutos(produto);
            return Ok (produtoDto);
        }




    }
}
