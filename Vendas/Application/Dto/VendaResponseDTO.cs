namespace Vendas.Application.Dto
{
    public class VendaResponseDTO
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public DateTime DataVenda { get; set; }
        public List<VendaItemResponseDTO> Itens { get; set; }
        public double ValorTotal { get; set; }

    }

    public class VendaItemResponseDTO
    {
        public int Id { get; set; }
        public long ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
    }
}
