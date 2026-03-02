using GerAlunosWIllian.Domain.Entities;

namespace GerAlunosWIllian.Application.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> ObterTodosAsync();
        Task<Aluno> ObterPorIdAsync(int id);
        Task AdicionarAsync(Aluno aluno);
        Task<bool> AtualizarAsync(int id, Aluno alunoAtualizado);
        Task<bool> DeletarAsync(int id);
    }
}