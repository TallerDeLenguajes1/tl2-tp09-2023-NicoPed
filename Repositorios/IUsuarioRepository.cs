using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp09_2023_NicoPed;

namespace Parcial2.Repositorios
{
    public interface IUsuarioRepository
{
    public List<Usuario> GetAllUsuarios();
    public Usuario GetUsuarioById(int id);
    public void CreateUsuario(Usuario usuario);
    public void RemoveUsuario(int id);
    public void Updateusuario(Usuario usuario);
}
}