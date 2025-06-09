using Vendas.Application.Dto;
using Vendas.Domain.Entities;
using Vendas.Infrastructure.Repositories;

namespace Vendas.Application.Services
{
    public class ProdutoService
    {
        private readonly ProdutoRepository _Repository;

        public ProdutoService(ProdutoRepository produtoRepository)
        {
            _Repository = produtoRepository;
        }

        public async Task<object> ListarTodosOsProdutos()
        {
            try
            {
                var produtos = await _Repository.ObterTodosOsProdutos();
                return produtos.Select(p => new ProdutoDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Unidade = p.Unidade,
                    Observacao = p.Observacao,
                    Preco = p.Preco,
                    DtCadastro = p.DtCadastro,
                }).ToList();
            }
            catch (Exception erro)
            {
                return "Erro ao listar os produtos." + erro;
            }
        }

        public async Task<ProdutoDTO> CadastrarProdutos(Produto produto)
        {
            try
            {
                var produtoSalvo = await _Repository.CadastrarProduto(produto);

                return new ProdutoDTO
                {
                    Id = produtoSalvo.Id,
                    Nome = produtoSalvo.Nome,
                    Unidade = produtoSalvo.Unidade,
                    Observacao = produtoSalvo.Observacao,
                    Preco = produtoSalvo.Preco,
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao cadastrar o produto: {ex.Message}");
            }
        }



    }
}
