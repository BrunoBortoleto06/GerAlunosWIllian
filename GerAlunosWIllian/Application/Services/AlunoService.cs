using GerAlunosWIllian.Application.DTOs;
using GerAlunosWIllian.Domain.Entities;
using GerAlunosWIllian.Domain.Interfaces;

namespace GerAlunosWIllian.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<IEnumerable<Aluno>> ObterTodosAsync()
        {
            return await _alunoRepository.ObterTodosAsync();
        }

        public async Task<Aluno> ObterPorIdAsync(Guid id)
        {
            return await _alunoRepository.ObterPorIdAsync(id);
        }

        public async Task AdicionarAsync(CreateAlunoDTO alunoDto)
        {
            if (string.IsNullOrWhiteSpace(alunoDto.FirstName))
            {
                throw new Exception("O primeiro nome é obrigatório.");
            }

            var novoAluno = new Aluno
            {
                FirstName = alunoDto.FirstName,
                LastName = alunoDto.LastName,
                Email = alunoDto.Email
            };

            await _alunoRepository.AdicionarAsync(novoAluno);
        }

        public async Task<bool> AtualizarAsync(Guid id, Aluno alunoAtualizado)
        {
            var alunoDesatualizado = await _alunoRepository.ObterPorIdAsync(id);

            if (alunoDesatualizado == null)
            {
                return false;
            }

            alunoDesatualizado.FirstName = alunoAtualizado.FirstName;
            alunoDesatualizado.LastName = alunoAtualizado.LastName;
            alunoDesatualizado.Email = alunoAtualizado.Email;

            await _alunoRepository.AtualizarAsync(alunoDesatualizado);
            return true;
        }

        public async Task<bool> DeletarAsync(Guid id)
        {
            var alunoExiste = await _alunoRepository.ObterPorIdAsync(id);

            if (alunoExiste == null)
            {
                return false;
            }

            await _alunoRepository.DeletarAsync(id);
            return true;
        }
    }
}