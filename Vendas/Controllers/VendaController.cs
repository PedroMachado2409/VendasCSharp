using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Dto;
using Vendas.Application.Services;

namespace Vendas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class VendaController : ControllerBase
    {
        private readonly VendaService _vendaService;

        public VendaController(VendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarVenda([FromBody] VendaRequestDTO dto)
        {
            await _vendaService.CriarVendaAsync(dto);
            return Ok(new { message = "Venda criada com sucesso!" });
        }

        [HttpGet]
        public async Task<IActionResult> ObterVendas()
        {
            var vendas = await _vendaService.ObterVendasAsync();
            return Ok(vendas);
        }
    }
}
