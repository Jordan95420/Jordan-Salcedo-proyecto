using Alphtmost.Modelos;
using Alphtmost.Servicios.Interfaz;
using AlphtmostAPI.Consumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphtmost.Servicios.Implementacion
{
    public class UsuarioClienteService : IUsuarioClienteService
    {
        // Aquí usas el servicio CRUD para interactuar con la API, sin usar DbContext
        public UsuarioCliente GetByEmail(string email)
        {
            try
            {
                // Usamos Crud<UsuarioCliente> para obtener el usuario por correo
                var usuario = Crud<UsuarioCliente>.GetByCampo("Email", email); // Llamada sincrónica
                return usuario.FirstOrDefault();  // Retorna el primer usuario encontrado o null si no hay
            }
            catch (Exception ex)
            {
                // Manejo del error: loguear o manejar el error de forma adecuada
                // Por ejemplo, podrías devolver un valor por defecto o re-lanzar el error.
                Console.WriteLine($"Error al obtener el usuario: {ex.Message}");
                return null; // Devolver null si la consulta falla
            }
        }

        public IEnumerable<UsuarioCliente> GetAllUsuarios()
        {
            try
            {
                // Usamos Crud<UsuarioCliente> para obtener todos los usuarios
                var usuarios = Crud<UsuarioCliente>.GetAll(); // Obtener todos los usuarios
                return usuarios;
            }
            catch (Exception ex)
            {
                // Manejo de error en la consulta
                Console.WriteLine($"Error al obtener todos los usuarios: {ex.Message}");
                return new List<UsuarioCliente>();  // Devolver una lista vacía si ocurre un error
            }
        }

        public UsuarioCliente CreateUsuario(UsuarioCliente usuario)
        {
            try
            {
                // Usamos Crud<UsuarioCliente> para crear un nuevo usuario
                var nuevoUsuario = Crud<UsuarioCliente>.Create(usuario);
                return nuevoUsuario;
            }
            catch (Exception ex)
            {
                // Manejo de error en la creación
                Console.WriteLine($"Error al crear el usuario: {ex.Message}");
                return null; // Devolver null si la creación falla
            }
        }
    }
}
