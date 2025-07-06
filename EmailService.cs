using MimeKit;
using MailKit.Net.Smtp;

public class EmailService
{
    public void EniarRegistroDeVerificacionEmail(string clientEmail, string verificationCode)
    {
        // Crear el mensaje
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Plataforma de Música", "noreply@musica.com"));
        message.To.Add(new MailboxAddress("", clientEmail));
        message.Subject = "Verifica tu cuenta en nuestra plataforma de música";

        // Crear el cuerpo del correo con el código de verificación
        var body = new TextPart("plain")
        {
            Text = GenerarCuerpoDelRegistro(verificationCode)
        };

        message.Body = body;

        // Enviar el correo usando MailKit
        using (var client = new SmtpClient())
        {
            client.Connect("smtp.gmail.com", 587, false); 
            client.Authenticate("tu-correo@gmail.com", "tu-contraseña-de-aplicacion"); // Crear cuenta para la aplicacion
            client.Send(message);
            client.Disconnect(true);
        }

        Console.WriteLine("Verification email enviado.");
    }


    private string GenerarCuerpoDelRegistro(string verificationCode)
    {
        var emailBody = "¡Gracias por registrarte en nuestra plataforma de música!\n\n";
        emailBody += "Para completar tu registro, por favor verifica tu cuenta haciendo clic en el siguiente enlace:\n\n";
        emailBody += $"https://www.musica.com/verify-email?code={verificationCode}\n\n";
        emailBody += "Si no solicitaste este registro, por favor ignora este correo.\n\n";
        emailBody += "¡Bienvenido a nuestra plataforma de música!";

        return emailBody;
    }
}
