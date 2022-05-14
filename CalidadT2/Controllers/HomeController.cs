using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CalidadT2.Models;
using CalidadT2.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    public class HomeController : Controller
    {
        private ILibroRepository libroRepository;
        private readonly AppBibliotecaContext context;
        public HomeController(ILibroRepository libroRepository)
        {
            this.libroRepository = libroRepository;
        }
        


        [HttpGet]
        public IActionResult Index()
        {            
            var model = libroRepository.GetAll_Libros();
            return View(model);
        }
    }
}
