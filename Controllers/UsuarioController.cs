using Microsoft.AspNetCore.Mvc;
using Parcial2.Repositorios;

namespace tl2_tp09_2023_NicoPed;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private UsuarioRepository repository = new UsuarioRepository();
    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        
        _logger = logger;
    }

    [HttpPost]
    [Route("Usuario")]
    public ActionResult<string> addUsuario(Usuario usuario){
        var resultado  = repository.CreateUsuario(usuario);
        if (resultado)
        {
            return Ok("usuario creado satisfactoriamente");
        }
        return BadRequest("Algo salio mal");
    }

    [HttpGet]
    [Route("Usuario")]
    public ActionResult<List<Usuario>> GetAllUsuarios(){
        var usuarios = repository.GetAllUsuarios();
        return Ok(usuarios);
    }
    
    [HttpGet]
    [Route("UsuarioByID")]
    public ActionResult<Usuario> GetUsuario(int id){
        var usuario = repository.GetUsuarioById(id);
        if (usuario != null)
        {
            return Ok(usuario);
        }
        return BadRequest("Usuario NO encontrado");
    }
    
    [HttpPut]
    [Route("Usuario{id}/Nombre")]
    public ActionResult<string> ModificarNombre(string nombre, Usuario usuario){
        var usu = repository.GetUsuarioById(usuario.Id_usuario);
        usu.Nombre_de_usuario = nombre;
        var resultado = repository.Updateusuario(usu);
        if (resultado)
        {
            return Ok("Nombre Actualizado");
        }
        return BadRequest("Algo salio mal");
    }
    
}
