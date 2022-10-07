using Bogus;
using CadastroAluno.Contratos;
using CadastroAluno.Controllers;
using CadastroAluno.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroAluno_Test
{
    public class AlunoControllerTest
    {

        private Mock<IAlunosRepository> _mockalunoservice;
        private AlunosController _alunoController;
        private Aluno AlunoTest;

        public AlunoControllerTest()
        {
            _mockalunoservice = new Mock<IAlunosRepository>();
            _alunoController = new AlunosController(_mockalunoservice.Object);

            AlunoTest = new Aluno()
            {
                Id = 4,
                Media = 7,
                Nome = "Gabriel",
                Turma = "T91"

            };

        }
        [Fact]
        public async void IndexRetornaViewResultComOuSemRegistrosNoBanco()
        {
            //Arrange
            AlunosController controller = new AlunosController(_mockalunoservice.Object);
            //Act
            var alunos = await controller.Index();
            //Assert
            Assert.IsType<ViewResult>(alunos.Result);
        }

        [Fact]
        public async void IndexDeveChamarORepositorioApenasUmaVez()
        {
            //Arrange
            AlunosController controller = new AlunosController(_mockalunoservice.Object);

            _mockalunoservice.Setup(r => r.GetAlunos());
            //Act
            await controller.Index();
            //Assert
            _mockalunoservice.Verify(Repo => Repo.GetAlunos(), Times.Once);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(null)]
        [InlineData(-1)]
        [InlineData(0)]

        public async void Details_DeveRetornarBadRequestParaIdNulo(int id)
        {
            //Arrange
            AlunosController controller = new AlunosController(_mockalunoservice.Object);

            var alunoid = id;
            //Act
            var Consulta = await controller.Details(alunoid);
            Assert.IsType<BadRequestObjectResult>(Consulta);
            //Erro, está retornando badRequest para todas as ocasiões 
        }

    }
}
