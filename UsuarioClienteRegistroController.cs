using Alphtmost.Servicios.Interfaz;
using Alphtmost.Modelos;
using Alphtmost.Servicios.VistasModelos;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

public class UsuarioClienteRegistroController : Controller
{
    private readonly IUsuarioClienteService _usuarioClienteService;
    private readonly ISendGridClient _sendGridClient;

    public UsuarioClienteRegistroController(IUsuarioClienteService usuarioClienteService, ISendGridClient sendGridClient)
    {
        _usuarioClienteService = usuarioClienteService;
        _sendGridClient = sendGridClient;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(UsuarioClienteRegistroViewModel model)
    {
        if (ModelState.IsValid)
        {
            var existingUser = _usuarioClienteService.GetByEmail(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Este correo ya está registrado.");
                return View(model);
            }

            model.ContraseñaHash = BCrypt.Net.BCrypt.HashPassword(model.ContraseñaHash);

            var newUser = new UsuarioCliente
            {
                Email = model.Email,
                ContraseñaHash = model.ContraseñaHash,
                Nombre = model.Nombre,
                Apellido = model.Apellido
            };

 
            _usuarioClienteService.CreateUsuario(newUser);  


            var verificationLink = Url.Action("ConfirmEmail", "UsuarioClienteRegistro", new { email = model.Email }, Request.Scheme);
            var emailMessage = new SendGridMessage()
            {
                From = new EmailAddress("alphtmostmusic@gmail.com", "Alphtmost Music"),
                Subject = "Confirma tu correo electrónico",
                PlainTextContent = $"Por favor, confirma tu correo haciendo click en este enlace: {verificationLink}",
                HtmlContent = $"<p>Por favor, confirma tu correo haciendo click en este enlace: <a href='{verificationLink}'>Confirmar correo</a></p>"
            };
            emailMessage.AddTo(model.Email);
            _sendGridClient.SendEmailAsync(emailMessage).Wait();  

            return RedirectToAction("Index", "Login");
        }

        return View(model);
    }

    public IActionResult ConfirmEmail(string email)
    {
        var user = _usuarioClienteService.GetByEmail(email);
        if (user == null)
        {
            ViewBag.Message = "No se encontró el usuario con ese correo.";
            return View("Error");
        }

        ViewBag.Message = "¡Correo confirmado exitosamente! Ahora puedes iniciar sesión.";
        return RedirectToAction("Index", "Login");
    }
}
