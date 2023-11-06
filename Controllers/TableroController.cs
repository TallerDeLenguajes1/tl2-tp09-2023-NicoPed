using Microsoft.AspNetCore.Mvc;
using Parcial2.Repositorios;

namespace tl2_tp09_2023_NicoPed;

[ApiController]
[Route("[controller]")]
public class TableroController : ControllerBase
{
    private TableroRepository repository = new TableroRepository();
    private readonly ILogger<TableroController> _logger;

    public TableroController(ILogger<TableroController> logger)
    {
        
        _logger = logger;
    }

    [HttpPost]
    [Route("Tablero")]
    public ActionResult<string> addTablerp(Tablero tablero){
        var resultado = repository.CreateTablero(tablero);
        if (resultado)
        {
            return Ok("Tablero creado satisfactoriamente");
        }
        return BadRequest("Algo salio mal");
    }

    [HttpGet]
    [Route("Tablero")]
    public ActionResult<List<Tablero>> GetAllTableros(){
        var tableros = repository.GetAllTableros();
        return Ok(tableros);
    }
    
}
