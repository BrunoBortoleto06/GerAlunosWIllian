using GerAlunosWIllian.Domain.Entities;

namespace GerAlunosWIllian.Domain.Interfaces
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> ObterTodosAsync();
        Task<Aluno> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(Aluno aluno);
        Task AtualizarAsync(Aluno aluno);
        Task DeletarAsync(Guid id);
    }
}