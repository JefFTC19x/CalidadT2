using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using CalidadT2.Repositories;
using CalidadT2.Controllers;
using CalidadT2.Models;
using Microsoft.AspNetCore.Mvc;
using CalidadT2.Services;
namespace Pruebas.Controllers
{
    class HomeControllerTest
    {
        [SetUp]
        public void SetUp()
        {
            var mock = new Mock<ILibroRepository>();
            
        }
        [Test]
        public void LoginError_Test()
        {
            var mock = new Mock<ILibroRepository>();
            mock.Setup(o => o.GetAll_Libros()).Returns(new List<Libro>());
            var controller = new HomeController(mock.Object);

            var result = controller.Index() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
