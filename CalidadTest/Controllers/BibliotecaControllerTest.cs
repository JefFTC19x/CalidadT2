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
    class BibliotecaControllerTest
    {
        [Test]
        public void TestIndex()
        {

            var mock = new Mock<IUsuarioRepo>();
            mock.Setup(o => o.LoggedUser()).Returns(new Usuario() { Id = 0});

            var bibliotecamock = new Mock<IBibliotecaRepository>();
            bibliotecamock.Setup(o => o.GetBibliotecaByUser(0)).Returns(new List<Biblioteca>());

            var controller = new BibliotecaController(mock.Object, bibliotecamock.Object);

            var result = controller.Index() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void TestAdd()
        {

            var mock = new Mock<IUsuarioRepo>();
            mock.Setup(o => o.LoggedUser()).Returns(new Usuario() { Id = 0 });

            var bibliotecamock = new Mock<IBibliotecaRepository>();
            
            var controller = new BibliotecaController(mock.Object, bibliotecamock.Object);

            var result = controller.Add(0);
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
        [Test]
        public void TestMarcarLeido()
        {

            var mock = new Mock<IUsuarioRepo>();
            mock.Setup(o => o.LoggedUser()).Returns(new Usuario() { Id = 0 });

            var bibliotecamock = new Mock<IBibliotecaRepository>();
            bibliotecamock.Setup(o => o.FindBibliotecaByLibro(0,0)).Returns(new Biblioteca());


            var controller = new BibliotecaController(mock.Object, bibliotecamock.Object);

            var result = controller.MarcarComoLeyendo(0);
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
        [Test]
        public void TestMarcarTerminado()
        {

            var mock = new Mock<IUsuarioRepo>();
            mock.Setup(o => o.LoggedUser()).Returns(new Usuario() { Id = 0 });

            var bibliotecamock = new Mock<IBibliotecaRepository>();
            bibliotecamock.Setup(o => o.FindBibliotecaByLibro(0, 0)).Returns(new Biblioteca());


            var controller = new BibliotecaController(mock.Object, bibliotecamock.Object);

            var result = controller.MarcarComoTerminado(0);
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
    }
}
