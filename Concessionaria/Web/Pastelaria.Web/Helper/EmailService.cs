using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Concessionaria.Web.Helper
{
    public class EmailService
    {
        public void EnviarEmail(string para, string assunto, string corpo)
        {
            using (MailMessage mensagem = new MailMessage())
            {
                using (SmtpClient cliente = new SmtpClient())
                {
                    cliente.Host = ConfigurationManager.AppSettings["smtp:Host"];
                    cliente.Port = int.Parse(ConfigurationManager.AppSettings["smtp:Port"]);
                    cliente.Credentials = new NetworkCredential(
                        ConfigurationManager.AppSettings["smtp:UserName"],
                        ConfigurationManager.AppSettings["smtp:Password"]
                    );
                    cliente.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["smtp:EnableSsl"]);

                    mensagem.From = new MailAddress(ConfigurationManager.AppSettings["smtp:From"]);
                    mensagem.To.Add(para);
                    mensagem.Subject = assunto;
                    mensagem.Body = corpo;
                    mensagem.IsBodyHtml = true;
                    mensagem.Priority = MailPriority.High;

                    try
                    {
                        cliente.Send(mensagem);
                    }
                    catch (Exception ex)
                    {
                        // Registrar o erro
                        Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
                    }
                }
            }
        }

    }
}