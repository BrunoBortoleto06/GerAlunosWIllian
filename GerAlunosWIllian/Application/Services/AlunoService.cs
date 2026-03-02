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

        public async Task<Aluno> ObterPorIdAsync(int id)
        {
            return await _alunoRepository.ObterPorIdAsync(id);
        }

        public async Task AdicionarAsync(Aluno aluno)
        {
            await _alunoRepository.AdicionarAsync(aluno);
        }

        public async Task<bool> AtualizarAsync(int id, Aluno alunoAtualizado)
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

        public async Task<bool> DeletarAsync(int id)
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