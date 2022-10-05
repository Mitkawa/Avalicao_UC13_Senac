using CadastroAluno.Contratos;
using CadastroAluno.Data;
using CadastroAluno.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAluno.Repository
{
    public class AlunoRepository : IAlunosRepository
    {
        private readonly CadastroAlunoContext _context;

        public AlunoRepository(CadastroAlunoContext context)
        {
            _context = context;
        }

        public async Task<List<Aluno>> GetAlunos()
        {
            return await _context.Aluno.ToListAsync();
        }

        public async Task<Aluno> GetAlunosById(int id)
        {
            return await _context.Aluno.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Aluno> AddAlunos(Aluno aluno)
        {

            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();

            return aluno;
        }

        public async Task<int> UpdateAluno(int id, Aluno alunoAlterado)
        {
            var aluno = await _context.Aluno.FirstOrDefaultAsync(a => a.Id == id);

            if (aluno == null)
                return 0;

            aluno.AtualizarDados(alunoAlterado.Nome, alunoAlterado.Turma);
            aluno.AtualizaMedia(alunoAlterado.Media);

            _context.Entry(aluno).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task DeleteAluno(int id)
        {
            var aluno = await _context.Aluno.FirstOrDefaultAsync(a => a.Id == id);

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
        }
    }
}
