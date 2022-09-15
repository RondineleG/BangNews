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
        public IActionResult NoticiaPorID(int NoticiaID)
        {
            return Ok(_noticiasServicio.ObtenerPorID(NoticiaID));
        }


        [Route("Salvar")]
        [HttpPost]
        public IActionResult Agregar([FromBody] Noticia NoticiaAgregar)
        {
            return _noticiasServicio.Agregar(NoticiaAgregar) ? Ok() : BadRequest();
        }

        [Route("Editar")]
        [HttpPut]
        public IActionResult Editar([FromBody] Noticia NoticiaEditar)
        {
            return _noticiasServicio.Editar(NoticiaEditar) ? Ok() : BadRequest();
        }


        [Route("Deletar/{noticiaID}")]
        [HttpDelete]
        public IActionResult Eliminar(int noticiaID)
        {
            return _noticiasServicio.Eliminar(noticiaID) ? Ok() : BadRequest();

        }

        [Route("ListaDeAutores")]
        [HttpGet]
        public IActionResult ListadoAutores()
        {
            return Ok(_noticiasServicio.ListadoDeAutores());
        }


        [Route("procedimientoSinDatos/{edad}/{nombre}")]
        [HttpGet]
        public IActionResult ProcedimientoSinDatos(int Edad, string Nombre)
        {
            return _autorServices.ProcedimientoQueNoDevuelveDatos(Edad, Nombre) ? Ok() : BadRequest();
        }


        [Route("procedimientoConDatos/{edad}/{nombre}")]
        [HttpGet]
        public IActionResult ProcedimientoConDatos(int Edad, string Nombre)
        {
            return Ok(_autorServices.ProcedimientoConValores(Edad, Nombre));
        }
    }

}