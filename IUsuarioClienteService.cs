using Alphtmost.Modelos;
using Alphtmost.Servicios.VistasModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphtmost.Servicios.Interfaz
{
    public interface IUsuarioClienteService
    {
        UsuarioCliente GetByEmail(string email);  // Sincrónico
        IEnumerable<UsuarioCliente> GetAllUsuarios();  // Sincrónico
        UsuarioCliente CreateUsuario(UsuarioCliente usuario);  // Sincrónico
    }
}
