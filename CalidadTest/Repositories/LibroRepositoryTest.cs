using CalidadT2.Models;
using CalidadT2.Repositories;
using Moq;
using NUnit.Framework;
using Pruebas.Repositories.Mock;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pruebas.Repositories
{
    class LibroRepositoryTest
    {
        private Mock<AppBibliotecaContext> mockContext;

        
        [SetUp]
        public void SetUp()
        {
            //mockContext = AplicationContextMock() ;
        }
        
        [Test]
        public void DetalleLibro_Test()
        {
            var repo = new LibroRepository(mockContext.Object);
            var libro = repo.DetalleLibro(1);

            Assert.IsNotNull(libro);
            Assert.AreEqual(libro.Nombre,"One Piece");
        } 
        
        [Test]
        public void GetAll_Libros_Test()
        {
            var repo = new LibroRepository(mockContext.Object);
            var libros = repo.GetAll_Libros();

            Assert.IsNotNull(libros);
        }
        
        [Test]
        public void GetLibroID_Test()
        {
            var repository = new LibroRepository(mockContext.Object);
            var libro = repository.GetLibroId(1);

            Assert.IsNotNull(libro);
            Assert.AreEqual(libro.Nombre, "One Piece");
        }
    }
}
