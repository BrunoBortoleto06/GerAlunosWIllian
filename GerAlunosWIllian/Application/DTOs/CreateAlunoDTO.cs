namespace GerAlunosWIllian.Application.DTOs
{
    public class CreateAlunoDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid CursoId { get; set; }
    }
}