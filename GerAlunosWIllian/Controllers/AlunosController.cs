using GerAlunosWIllian.Application.Services;
using GerAlunosWIllian.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerAlunosWIllian.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAluno(Aluno aluno)
        {
            await _alunoService.AdicionarAsync(aluno);
            return Ok(aluno);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            var alunos = await _alunoService.ObterTodosAsync();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            var aluno = await _alunoService.ObterPorIdAsync(id);
            if (aluno == null) return NotFound("Aluno não encontrado!");

            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAluno(int id, [FromBody] Aluno alunoAtualizado)
        {
            var sucesso = await _alunoService.AtualizarAsync(id, alunoAtualizado);

            if (!sucesso) return NotFound("Aluno não encontrado!");

            return StatusCode(201, alunoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            var sucesso = await _alunoService.DeletarAsync(id);

            if (!sucesso) return NotFound("Aluno não encontrado!");

            return Ok("Aluno deletado com sucesso!");
        }
    }
}