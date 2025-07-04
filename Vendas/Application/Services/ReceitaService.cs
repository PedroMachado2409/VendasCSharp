﻿using AutoMapper;
using System.Runtime.CompilerServices;
using Vendas.Application.Dto;
using Vendas.Domain.Entities;
using Vendas.Infrastructure.Repositories;

namespace Vendas.Application.Services
{
    public class ReceitaService
    {
        private readonly ReceitaRepository _receitaRepository;
        private readonly ClienteRepository _clienteRepository;
        private readonly AuthService _authService;
        private readonly IMapper _mapper;

        public ReceitaService(ReceitaRepository receitaRepository, ClienteRepository clienteRepository, IMapper mapper, AuthService service)
        {
            _receitaRepository = receitaRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _authService = service;
        }

        public async Task<ReceitaDTO> CadastrarReceita(ReceitaDTO receitaDto)
        {
            var cliente = await _clienteRepository.ObterClientePorId(receitaDto.ClienteId);
            var usuario = await _authService.ObterUsuarioAutenticadoAsync();
            if (cliente == null)
            {
                throw new ArgumentException("Cliente não encontrado.");
            }
            var receita = _mapper.Map<Receita>(receitaDto);
            receita.Cliente = cliente;
            receita.UsuarioId = usuario.Id;
            receitaDto.UsuarioNome = usuario.Nome;

            var receitaCadastrada = await _receitaRepository.CadastrarReceita(receita);
            return _mapper.Map<ReceitaDTO>(receitaCadastrada);
        }

        public async Task<List<ReceitaDTO>> ObterTodasAsReceitas()
        {
            var receitas = await _receitaRepository.ObterTodasAsReceitas();
            return _mapper.Map<List<ReceitaDTO>>(receitas);
        }

        public async Task<ReceitaDTO?> ObterReceitaPorId(int id)
        {
            var receita = await _receitaRepository.ObterReceitaPorId(id);
            return receita != null ? _mapper.Map<ReceitaDTO>(receita) : null;

        }

        public async Task<Receita> BaixarReceita(int id)
        {
            var receita = await _receitaRepository.ObterReceitaPorId(id);
            if (receita == null)
            {
                throw new ArgumentException("Receita não encontrada.");
            }
            receita.StBaixado = true;
            return await _receitaRepository.BaixarReceita(receita);
        }
    }
}
