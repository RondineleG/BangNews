using BangNews.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BangNews.Api.Data;

namespace BangNews.Api.Services
{
    public class NoticiaServices
    {
        public readonly BangNewsApiContext _NoticiaDB;
        public NoticiaServices(BangNewsApiContext NoticiaDB)
        {
            _NoticiaDB = NoticiaDB;
        }

        public List<Noticia> VerListadoTodasLasNoticias()
        {
            var NoticiaBuscada = _NoticiaDB.Noticia.Include(x => x.Autor).OrderByDescending(x => x.NoticiaID).ToList();
            return NoticiaBuscada;
        }

        public Noticia ObtenerPorID(int NoticiaID)
        {
            try
            {
                var NoticiaBuscada = _NoticiaDB.Noticia.Where(x => x.NoticiaID == NoticiaID).FirstOrDefault();
                var autor = _NoticiaDB.Autor.Where(x => x.AutorID == NoticiaBuscada.AutorID).FirstOrDefault();

                return NoticiaBuscada;
            }
            catch (Exception error)
            {
                return new Noticia();
            }
        }
        public bool Agregar(Noticia NoticiaAgregar)
        {
            try
            {
                _NoticiaDB.Noticia.Add(NoticiaAgregar);
                _NoticiaDB.SaveChanges();
                return true;
            }
            catch (Exception error)
            {
                return false;
            }

        }


        public bool Editar(Noticia NoticiaEditar)
        {
            try
            {
                var noticia = _NoticiaDB.Noticia.FirstOrDefault(x => x.NoticiaID == NoticiaEditar.NoticiaID);
                noticia.Titulo = NoticiaEditar.Titulo;
                noticia.Descripcion = NoticiaEditar.Descripcion;
                noticia.Contenido = NoticiaEditar.Contenido;
                noticia.Fecha = NoticiaEditar.Fecha;
                noticia.AutorID = NoticiaEditar.AutorID;
                _NoticiaDB.SaveChanges();
                return true;
            }
            catch (Exception error)
            {
                return false;
            }

        }

        public bool Eliminar(int NoticiaID)
        {
            try
            {
                var noticiaEliminar = _NoticiaDB.Noticia.FirstOrDefault(x => x.NoticiaID == NoticiaID);
                _NoticiaDB.Noticia.Remove(noticiaEliminar);
                _NoticiaDB.SaveChanges();
                return true;
            }
            catch (Exception error)
            {
                return true;
            }
        }
    }
}
