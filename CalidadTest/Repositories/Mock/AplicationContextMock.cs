using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalidadTest.Helper;
using CalidadT2.Models;
using NUnit.Framework;

namespace Pruebas.Repositories.Mock
{
    class AplicationContextMock
    {
        

        private IQueryable<Biblioteca> data;
        private Mock<AppBibliotecaContext> mockDB;

        [SetUp]
        public void SetUp()
        {
            data = new List<Biblioteca>
            {
                new Biblioteca(){Id = 1, UsuarioId = 1, LibroId = 1},
                new Biblioteca(){Id = 2, UsuarioId = 2, LibroId = 1}
            }.AsQueryable();

            var mockAppContextUsuario = new MockDbSet<Biblioteca>(data);
            mockDB = new Mock<AppBibliotecaContext>();
            mockDB.Setup(o => o.Bibliotecas).Returns(mockAppContextUsuario.Object);
        }
    }
}
