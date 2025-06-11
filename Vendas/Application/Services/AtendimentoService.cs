using AutoMapper;
using Vendas.Application.Dto;
using Vendas.Domain.Entities;
using Vendas.Infrastructure.Repositories;

namespace Vendas.Application.Services
{
    public class AtendimentoService
    {
        private readonly AtendimentoRepository _atendimentoRepository;
        private readonly IMapper _mapper;
        private readonly AuthService _authService;

        public AtendimentoService(AtendimentoRepository atendimentoRepository, AuthService service, IMapper mapper)
        {
            _atendimentoRepository = atendimentoRepository;
            _authService = service;
            _mapper = mapper;
        }

        public async Task<List<AtendimentoDTO>> ObterTodosOsAtendimentosAsync()
        {
            var atendimentos = await _atendimentoRepository.ObterTodosOsAtendimentos();
            return _mapper.Map<List<AtendimentoDTO>>(atendimentos);
        }

        public async Task<AtendimentoDTO> CriarAtendimentoAsync(AtendimentoDTO dto)
        {
            var atendimento = new Atendimento
            {
                ClienteId = dto.ClienteId,
                DataHora = DateTime.UtcNow,
                Descricao = dto.Descricao,
                Pareceres = new List<Parecer>()
            };

            await AdicionarPareceres(atendimento, dto.Pareceres);

            var atendimentoCriado = await _atendimentoRepository.CriarAtendimento(atendimento);
            return _mapper.Map<AtendimentoDTO>(atendimentoCriado);
        }

        public async Task<AtendimentoDTO?> ObterAtendimentoPorIdAsync(int id)
        {
            var atendimento = await _atendimentoRepository.ObterAtendimentoPorId(id);
            if (atendimento == null)
            {
                return null;
            }
            return _mapper.Map<AtendimentoDTO>(atendimento);
        }

        public async Task<AtendimentoDTO> AdicionarParecer(int id, ParecerDTO parecerDto)
        {
            var atendimento = await _atendimentoRepository.ObterAtendimentoPorId(id);
            if (atendimento == null)
            {
                throw new KeyNotFoundException("Atendimento não encontrado.");
            }

            var usuario = await _authService.ObterUsuarioAutenticadoAsync();
            if (usuario == null)
            {
                throw new UnauthorizedAccessException("Usuário não autenticado.");
            }

            var parecer = new Parecer
            {
                Descricao = parecerDto.Descricao,
                UsuarioId = usuario.Id,
                DataHora = DateTime.UtcNow,
                Codigo = Guid.NewGuid()
            };

            atendimento.Pareceres.Add(parecer);

            var atendimentoAtualizado = await _atendimentoRepository.AtualizarAtendimento(atendimento);
            return _mapper.Map<AtendimentoDTO>(atendimentoAtualizado);
        }


        //------------------------METODOS PRIVADOS------------------------//

        private async Task AdicionarPareceres(Atendimento atendimento, List<ParecerDTO> pareceresDto)
        {
            foreach (var parecerDto in pareceresDto)
            {
                var usuario = await _authService.ObterUsuarioAutenticadoAsync();

                if (usuario == null)
                {
                    throw new UnauthorizedAccessException("Usuário não autenticado.");
                }

                var parecer = new Parecer
                {
                    Descricao = parecerDto.Descricao,
                    UsuarioId = usuario.Id,
                    DataHora = DateTime.UtcNow,
                    Codigo = Guid.NewGuid() // Assuming Codigo is generated here
                };

                atendimento.Pareceres.Add(parecer);
            }
        }
    }
}
