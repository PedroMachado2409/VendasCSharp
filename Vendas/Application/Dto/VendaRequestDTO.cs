using System.ComponentModel.DataAnnotations;

namespace Vendas.Application.Dto
{
    public class VendaRequestDTO
    {

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public List<VendaItemRequestDTO> Itens { get; set; }
    }

    public class VendaItemRequestDTO
    {
        [Required]
        public long ProdutoId { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public double PrecoUnitario { get; set; }
    }
}
