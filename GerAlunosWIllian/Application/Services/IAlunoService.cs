using GerAlunosWIllian.Application.DTOs;
using GerAlunosWIllian.Domain.Entities;

namespace GerAlunosWIllian.Application.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> ObterTodosAsync();
        Task<Aluno> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(CreateAlunoDTO alunoDto);
        Task<bool> AtualizarAsync(Guid id, Aluno alunoAtualizado);
        Task<bool> DeletarAsync(Guid id);
    }
}