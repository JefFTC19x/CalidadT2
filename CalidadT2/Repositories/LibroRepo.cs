using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalidadT2.Repositories
{
    public interface ILibroRepository
    {
        List<Libro> GetAll_Libros();
        Libro DetalleLibro(int id);
        void HacerComentario(Comentario comentario, int userid);
        Libro GetLibroId(int id);
        void PuntuacionLibro(Libro libro, Comentario comentario);

    }
    public class LibroRepository : ILibroRepository
    {
        private readonly AppBibliotecaContext _context;

        public LibroRepository(AppBibliotecaContext context)
        {
            this._context = context;
        }

        public void HacerComentario(Comentario comentario,int userid)
        {
            comentario.UsuarioId = userid;
            comentario.Fecha = DateTime.Now;
            _context.Comentarios.Add(comentario);

        }

        public Libro DetalleLibro(int id)
        {
            return _context.Libros
                .Include("Autor")
                .Include("Comentarios.Usuario")
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }

        public List<Libro> GetAll_Libros()
        {
            return _context.Libros.Include(o => o.Autor).ToList(); 
        }

        public Libro GetLibroId(int id)
        {
            return _context.Libros.Where(o => o.Id == id).First();
        }

        public void PuntuacionLibro(Libro libro,Comentario comentario)
        {
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;
            _context.SaveChanges();
        }
    }
}
