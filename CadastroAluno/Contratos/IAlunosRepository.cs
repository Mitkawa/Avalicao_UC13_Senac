using CadastroAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAluno.Contratos
{
    public interface IAlunosRepository
    {
        Task<List<Aluno>> GetAlunos();

        Task<Aluno> GetAlunosById(int id);

        Task<Aluno> AddAlunos(Aluno aluno);

        Task<int> UpdateAluno(int id, Aluno alunoAlterado);

        Task DeleteAluno(int id);
    }
}
