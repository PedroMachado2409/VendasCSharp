namespace Vendas.Application.Dto
{
    public class SaldoDTO
    {
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; } = string.Empty;
        public decimal Saldo { get; set; }
       
    }
}
