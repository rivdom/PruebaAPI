using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaAPI.Models;
using PruebaAPI.Models.DTO;
using PruebaAPI.Repositories.IRepositories;

namespace PruebaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadoresController : ControllerBase
    {
        private readonly ITrabajadorRepository _repository;  
        private readonly IMapper _mapper;
        public TrabajadoresController(ITrabajadorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetTrabajadores()
        {
            var listaTrabajadores = _repository.GetTrabajadores();

            var listaTrabajadoresDTO = new List<TrabajadorDTO>();
            //convierto trabajdores a trabajadoresDTO para no exponer el modelo
            foreach (var trabajador in listaTrabajadores)
            {
                listaTrabajadoresDTO.Add(_mapper.Map<TrabajadorDTO>(trabajador));
            }
            return Ok(listaTrabajadoresDTO);
        }
        [HttpGet("{trabajadorId:int}", Name = "GetOneTrabajador")]  
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetOneTrabajador(int trabajadorId)
        {
            var trabajador = _repository.GetOneTrabajador(trabajadorId);

            if (trabajador == null) return NotFound();

            var trabajadorDTO = _mapper.Map<TrabajadorDTO>(trabajador);

            return Ok(trabajadorDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //El FromBody quiere decir que viene en el cuerpo de la petición
        public IActionResult CreateTrabajador([FromBody] CrearTrabajadorDTO trabajadorDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (trabajadorDTO == null) return BadRequest();

            var trabajador = _mapper.Map<Trabajador>(trabajadorDTO);

            if (!_repository.CreateTrabajador(trabajador))
            {
                ModelState.AddModelError("", $"Se ha producido un error creando el trabajador {trabajador.Nombre}");
                return StatusCode(400, ModelState);
            }
            //Este metodo nos devuelve la ruta de este nuevo registro creado
            return CreatedAtRoute("GetOneTrabajador", new { trabajadorId = trabajador.Id }, trabajador);
        }

        [HttpPatch("{trabajadorId:int}", Name = "UpdateTrabajador")] 
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateTrabajador(int trabajadorId, [FromBody] TrabajadorDTO trabajadorDTO)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (trabajadorDTO == null) return BadRequest(ModelState);

            var trabajador = _mapper.Map<Trabajador>(trabajadorDTO);

            if (!_repository.UpdateTrabajador(trabajador))
            {
                ModelState.AddModelError("", $"Se ha producido un error actualizando la trabajador {trabajador.Nombre}");
                return StatusCode(500, ModelState);
            }
            //Esto es lo que se retorna cuando actualizamos
            return NoContent();

        }

        [HttpDelete("{trabajadorId:int}", Name = "DeleteTrabajador")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteTrabajador(int trabajadorId)
        {
            var trabajador = _repository.GetOneTrabajador(trabajadorId);

            //si algo sale mal, si no se borrara
            if (!_repository.DeleteTrabajador(trabajador))
            {
                ModelState.AddModelError("", $"Se ha producido un error borrando el trabajador {trabajador.Nombre}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
