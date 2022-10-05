using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroAluno.Data;
using CadastroAluno.Models;
using CadastroAluno.Contratos;

namespace CadastroAluno.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunosRepository _alunosRepository;

        public AlunosController(IAlunosRepository alunosRepository)
        {
            _alunosRepository = alunosRepository;
        }

        public async Task<ActionResult<IEnumerable<Aluno>>> Index()
        {
            return View(await _alunosRepository.GetAlunos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> Details(int id)
        {
            var Aluno = await _alunosRepository.GetAlunosById(id);

            if (Aluno == null)
            {
                return NotFound();
            }

            return View(Aluno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Aluno aluno)
        {
            var totalAlteracoes = await _alunosRepository.UpdateAluno(id, aluno);

            if (totalAlteracoes == 0)
                return NotFound();

            return Ok("Alterações realizadas com sucesso!");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> Create(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(aluno);
            }

            var result = await _alunosRepository.AddAlunos(aluno);

            return CreatedAtAction("GetAlunos", new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            await _alunosRepository.DeleteAluno(id);
            return NoContent();
        }
    }
}
