using Alphtmost.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphtmost.Servicios.Interfaz
{
    public interface IArtistaClienteService
    {
        Task<ArtistaCliente> ObtenerUsuarioPorEmailAsync(string email);  // Obtener usuario por email
        Task<bool> VerificarContraseñaAsync(string email, string password);  // Verificar contraseña
        Task<bool> EsUsuarioVerificadoAsync(string email);  // Verificar si el usuario ha confirmado su cuenta
        Task<string> GenerarTokenJwtAsync(ArtistaCliente artistaCliente);  // Generar token JWT
    }
}
