using CadastroAluno.Contratos;
using CadastroAluno.Controllers;
using CadastroAluno.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroAluno_Test
{
    public class CadastroAlunoTest
    {
        //private Mock<IAlunosRepository> _mockalunoservice;
        //private AlunosController _alunoController;
        private Aluno _alunotest;

        public CadastroAlunoTest()
        {
            //_mockalunoservice = new Mock<IAlunosRepository>();
            //_alunoController = new AlunosController(_mockalunoservice.Object);
            _alunotest = new Aluno
            {
                Id = 4,
                Media = 7,
                Nome = "Gabriel",
                Turma = "T91"

            };
        }
        
        [Fact]
        public void AtualizaDados_ERetornaDadosAtualizados()
        {
            //Arrange
            //act
            _alunotest.AtualizarDados("","");
            //assert
            Assert.Equal("", _alunotest.Nome);



        }
    }
}
