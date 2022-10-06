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

        [Theory]
        [InlineData("Miguel","T94")]
        [InlineData("Kaue", "T44")]
        [InlineData(null, "T44")]
        public void AtualizaDados_ERetornaDadosAtualizadoss(string aluno, string turma)
        {
            //Arrange
            Aluno AlunoTest = new Aluno();
                AlunoTest.Nome = aluno;
                AlunoTest.Turma = turma;
                ;
            //act
            _alunotest.AtualizarDados(AlunoTest.Nome, AlunoTest.Turma);
            //assert
            Assert.Equal(AlunoTest.Nome, aluno);
            Assert.Equal(AlunoTest.Turma, turma);
        }

        [Theory]
        [InlineData(7)]
        [InlineData(6)]
        [InlineData(9)]
        public void VerificaAprovaçãoERetornaVerdadeiroSeMaiorQ5ERetornaTrue(double media)
        {
            //Arrange
            Aluno AlunoTest = new Aluno();
            AlunoTest.Media = media;
            ;
            //act
            
            //assert
            Assert.True(AlunoTest.VerificaAprovacao());
        }

        [Theory]
        [InlineData(7)]
        [InlineData(6)]
        [InlineData(9)]
        public void VerificaAtualizaMediaERetornaValorAtualizado(double media)
        {
            //Arrange
            Aluno AlunoTest = new Aluno();
            AlunoTest.Media = media;
            ;
            //act

            //assert
            Assert.Equal(AlunoTest.Media,media);
        }

    }
}
