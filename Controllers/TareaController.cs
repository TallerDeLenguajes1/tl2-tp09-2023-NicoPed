using Microsoft.AspNetCore.Mvc;
using Parcial2.Repositorios;

namespace tl2_tp09_2023_NicoPed;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    private TareaRepository repository = new TareaRepository();
    private readonly ILogger<TareaController> _logger;

    public TareaController(ILogger<TareaController> logger)
    {
        
        _logger = logger;
    }

    [HttpPost]
    [Route("Tarea")]
    public ActionResult<string> addTarea(Tarea tarea){
        var resultado  = repository.CreateTarea(tarea);
        if (resultado)
        {
            return Ok("usuario creado satisfactoriamente");
        }
        return BadRequest("Algo salio mal");
    }

    [HttpGet]
    [Route("Usuario/Estado")]
    public ActionResult<List<Tarea>> GetAllUsuarios(Tarea.estadoTarea estado){
        var resultado = repository.CantTareasEnUnEstado(estado);
        return Ok(resultado);
    }
    
    [HttpGet]
    [Route("TareasDeUnUsuario")]
    public ActionResult<List<Tarea>> GetTareasDeUnUsuario(int id_usuario){
        var tareas = repository.GetAllUsersTareas(id_usuario);
        return Ok(tareas);
    }
    [HttpGet]
    [Route("TareasDeUnTablero")]
    public ActionResult<List<Tarea>> TareasDeUnTablero(int id_tablero){
        var tareas = repository.GetAllTablerosTareas(id_tablero);
        return Ok(tareas);
    }
    
    [HttpPut]
    [Route("Tarea{id}/Nombre")]
    public ActionResult<string> ModificarNombre(string nombre, Tarea tarea){
        var tare = repository.GetTareaById(tarea.Id_tarea);
        tare.Nombre = nombre;
        var resultado = repository.UpdateTarea(tare);
        if (resultado)
        {
            return Ok("Nombre Actualizado");
        }
        return BadRequest("Algo salio mal");
    }

    [HttpPut]
    [Route("Tarea{id}/Estado")]
    public ActionResult<string> ModificarEstado(Tarea.estadoTarea estado, Tarea tarea){
        var tare = repository.GetTareaById(tarea.Id_tarea);
        tare.Estado = estado;
        var resultado = repository.UpdateTarea(tare);
        if (resultado)
        {
            return Ok("Nombre Actualizado");
        }
        return BadRequest("Algo salio mal");
    }
    
}
