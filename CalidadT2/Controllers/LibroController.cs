using System;
using System.Linq;
using CalidadT2.Models;
using CalidadT2.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    public class LibroController : Controller
    {

        private readonly IUsuarioRepo _usuarioRepo;
        private readonly ILibroRepository libroRepository;
        public LibroController(ILibroRepository libroRepository, IUsuarioRepo usuarioRepo)
        {
            this._usuarioRepo = usuarioRepo;
            this.libroRepository = libroRepository;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = libroRepository.DetalleLibro(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddComentario(Comentario comentario)
        {
            Usuario user = LoggedUser();
            libroRepository.HacerComentario(comentario,user.Id);

            var libro = libroRepository.GetLibroId(comentario.LibroId);
            libroRepository.PuntuacionLibro(libro,comentario);

            return RedirectToAction("Details", new { id = comentario.LibroId });
        }

        private Usuario LoggedUser()
        {
            return _usuarioRepo.LoggedUser();
        }
    }
}
