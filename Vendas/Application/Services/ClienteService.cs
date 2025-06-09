using AutoMapper;
using Vendas.Application.Dto;
using Vendas.Domain.Entities;
using Vendas.Infrastructure.Repositories;

namespace Vendas.Application.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _repository;
        private readonly IMapper _mapper;

        public ClienteService(ClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ClienteDTO>> ObterTodosClientes()
        {
            var clientes = await _repository.ObterTodosClientes();
            return _mapper.Map<List<ClienteDTO>>(clientes);
        }

        public async Task<ClienteDTO?> ObterClientePorId(int id)
        {
            var cliente = await _repository.ObterClientePorId(id);
            return cliente is null ? null : _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<ClienteDTO> CadastrarCliente(ClienteDTO clienteDto)
        {
            var entidade = _mapper.Map<Cliente>(clienteDto);
            var clienteCadastrado = await _repository.CadastrarCliente(entidade);
            return _mapper.Map<ClienteDTO>(clienteCadastrado);
        }

        public async Task<List<ClienteDTO>> ObterClientesAtivos()
        {
            var clientesAtivos = await _repository.ObterClientesAtivos();
            return _mapper.Map<List<ClienteDTO>>(clientesAtivos);
        }
    }
}
