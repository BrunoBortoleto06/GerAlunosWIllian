using GerAlunosWIllian.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerAlunosWIllian.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Aluno> Alunos { get; set; }

    }
}
