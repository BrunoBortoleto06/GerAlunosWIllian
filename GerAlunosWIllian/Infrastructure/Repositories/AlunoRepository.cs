using GerAlunosWIllian.Domain.Entities;
using GerAlunosWIllian.Domain.Interfaces;
using GerAlunosWIllian.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GerAlunosWIllian.Infrastructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppDbContext _context;

        public AlunoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Aluno>> ObterTodosAsync()
        {
            return await _context.Alunos.Include(a => a.Curso).ToListAsync();
        }

        public async Task<Aluno> ObterPorIdAsync(Guid id)
        {
            return await _context.Alunos.Include(a => a.Curso).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> EmailJaExisteAsync(string email)
        {
            return await _context.Alunos.AnyAsync(a => a.Email == email);
        }

        public async Task AdicionarAsync(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
            }
        }
    }
}