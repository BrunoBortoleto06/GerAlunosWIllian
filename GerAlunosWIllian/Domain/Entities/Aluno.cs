namespace GerAlunosWIllian.Domain.Entities
{
    public class Aluno : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}