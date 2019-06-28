using BangNews.Api.Data;
using BangNews.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BangNews.Api.Services
{
    public class AutorServices
    {
        public readonly BangNewsApiContext _BangNewsDB;
        public AutorServices(BangNewsApiContext BangNewsDB)
        {
            _BangNewsDB = BangNewsDB;
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
                string query = "spSinValoresDesdeProcedimiento @Edad={0}, @Nombre='{1}'";
                query = string.Format(query, Edad, Nombre);
                _BangNewsDB.Database.ExecuteSqlCommand(query);
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
                    = _BangNewsDB.Nombres.FromSql($"spValoresDesdeProcedimiento @Edad, @Nombre", parametroEdad, parametroNombre).ToList();
                return nombresRecibidosDeBaseDeDatos;
            }
            catch (Exception ex)
            {
                return new List<Nomes>();
            }
        }
    }
}
