using BangNews.Api.Data;
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
        public readonly BangNewsApiContext _BangNewsDB;
        public NoticiaServices(BangNewsApiContext BangNewsDB)
        {
            _BangNewsDB = BangNewsDB;
        }

        public List<Noticia> VerListadoTodasLasNoticias()
        {
            var NoticiaBuscada = _BangNewsDB.Noticias.Include(x => x.Autor).OrderByDescending(x => x.NoticiaID).ToList();
            return NoticiaBuscada;
        }

        public Noticia ObtenerPorID(int NoticiaID)
        {
            try
            {
                var NoticiaBuscada = _BangNewsDB.Noticias.Where(x => x.NoticiaID == NoticiaID).FirstOrDefault();
                var autor = _BangNewsDB.Autor.Where(x => x.AutorID == NoticiaBuscada.AutorID).FirstOrDefault();

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
                _BangNewsDB.Noticias.Add(NoticiaAgregar);
                _BangNewsDB.SaveChanges();
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
                var noticia = _BangNewsDB.Noticias.FirstOrDefault(x => x.NoticiaID == NoticiaEditar.NoticiaID);
                noticia.Titulo = NoticiaEditar.Titulo;
                noticia.Descricao = NoticiaEditar.Descricao;
                noticia.Conteudo = NoticiaEditar.Conteudo;
                noticia.DataCadastro = NoticiaEditar.DataCadastro;
                noticia.AutorID = NoticiaEditar.AutorID;
                _BangNewsDB.SaveChanges();
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
                var noticiaEliminar = _BangNewsDB.Noticias.FirstOrDefault(x => x.NoticiaID == NoticiaID);
                _BangNewsDB.Noticias.Remove(noticiaEliminar);
                _BangNewsDB.SaveChanges();
                return true;
            }
            catch (Exception error)
            {
                return true;
            }
        }
        public List<Autor> ListadoDeAutores()
        {
            try
            {
                var autores = _BangNewsDB.Autor.ToList();

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
                string query = "spSinValoresDesdeProcedimiento @Edad={0}, @Nome='{1}'";
                query = string.Format(query, Edad, Nombre);
                _BangNewsDB.Database.ExecuteSqlCommand(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public List<Nome> ProcedimientoConValores(int Edad, string Nombre)
        {
            try
            {
                SqlParameter parametroEdad = new SqlParameter("@Edad", Edad);
                SqlParameter parametroNombre = new SqlParameter("@Nome", Nombre);
                List<Nome> nombresRecibidosDeBaseDeDatos
                    = _BangNewsDB.Nomes.FromSql($"spValoresDesdeProcedimiento @Edad, @Nome", parametroEdad, parametroNombre).ToList();
                return nombresRecibidosDeBaseDeDatos;
            }
            catch (Exception ex)
            {
                return new List<Nome>();
            }
        }
    }
}
