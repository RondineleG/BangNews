using BangNews.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BangNews.Api.Services
{
    public class NoticiaServices
    {
        public readonly NoticiasDBContext _NoticiaDB;
        public NoticiaServices(NoticiasDBContext NoticiaDB)
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
              var NoticiaBuscada =  _NoticiaDB.Noticia.Where(x => x.NoticiaID == NoticiaID).FirstOrDefault();
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
            catch(Exception error)
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
            catch(Exception error)
            {
                return true;
            }
        }


        public List<Autor> ListadoDeAutores()
        {
            try
            {
                var autores = _NoticiaDB.Autor.ToList();
               
                return autores;
            }
            catch (Exception error)
            {
                return new List<Autor>();
            }
        }

        public bool ProcedimientoQueNoDevuelveDatos(int Edad, string Nombre)
        {
            try
            {
                string query = "spSinValoresDesdeProcedimiento @Edad={0}, @Nombre='{1}'";
                query = string.Format(query, Edad, Nombre);
                _NoticiaDB.Database.ExecuteSqlCommand(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public List<Nomes> ProcedimientoConValores(int Edad, string Nombre)
        {
            try
            {
                SqlParameter parametroEdad = new SqlParameter("@Edad", Edad);
                SqlParameter parametroNombre = new SqlParameter("@Nombre", Nombre);
                List<Nomes> nombresRecibidosDeBaseDeDatos
                    = _NoticiaDB.Nombres.FromSql($"spValoresDesdeProcedimiento @Edad, @Nombre", parametroEdad, parametroNombre).ToList();
                return nombresRecibidosDeBaseDeDatos;
            }
            catch (Exception ex)
            {
                return new List<Nomes>();
            }
        }
    }
}
