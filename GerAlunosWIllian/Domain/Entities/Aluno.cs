using System.ComponentModel.DataAnnotations;

namespace GerAlunosWIllian.Domain.Entities
{
    public class Aluno
    {
        public int Id { get; set; }

        public string FirstName { get; set; }   

        public string LastName { get; set; }

        public string Email { get; set; }
    }


}
