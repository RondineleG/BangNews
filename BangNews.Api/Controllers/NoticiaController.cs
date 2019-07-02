using BangNews.Api.Models;
using BangNews.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BangNews.Api.Controllers
{
    [Route("api/noticias")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly NoticiaServices _noticiasServicio;
        private readonly AutorServices _autorServices;
        public NoticiaController(NoticiaServices noticiasServicio)
        {
            _noticiasServicio = noticiasServicio;
        }
        

        [Route("TodasNoticias")]
        [HttpGet]
        public IActionResult VerNoticias()
        {
            var resultado = _noticiasServicio.VerListadoTodasLasNoticias();
            return Ok(resultado);
        }

        [Route("NoticiaPorID/{NoticiaID}")]
        [HttpGet]
        public IActionResult NoticiaPorID( int NoticiaID)
        {
            return Ok(_noticiasServicio.ObtenerPorID(NoticiaID));
        }


        [Route("Salvar")]
        [HttpPost]
        public IActionResult Agregar([FromBody] Noticia NoticiaAgregar)
        {
            if (_noticiasServicio.Agregar(NoticiaAgregar))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


         


        [Route("Editar")]
        [HttpPut]
        public IActionResult Editar([FromBody] Noticia  NoticiaEditar)
        {
            if (_noticiasServicio.Editar(NoticiaEditar))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

   

        [Route("Deletar/{noticiaID}")]
        public IActionResult Eliminar(int noticiaID)
        {
            if (_noticiasServicio.Eliminar(noticiaID))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }



        [Route("ListaDeAutores")]
        public IActionResult ListadoAutores()
        {
            return Ok(_noticiasServicio.ListadoDeAutores());
        }


        [Route("procedimientoSinDatos/{edad}/{nombre}")]
        [HttpGet]
        public IActionResult ProcedimientoSinDatos(int Edad, string Nombre)
        {
            if (_autorServices.ProcedimientoQueNoDevuelveDatos(Edad, Nombre))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [Route("procedimientoConDatos/{edad}/{nombre}")]
        [HttpGet]
        public IActionResult ProcedimientoConDatos(int Edad, string Nombre)
        {
            return Ok(_autorServices.ProcedimientoConValores(Edad, Nombre));
        }
    }

}