
using Concessionaria.Web.Application.Email.Model;
using Concessionaria.Web.Application.Infra;
using Concessionaria.Web.Application.Infra.Extensions;
using System.Collections.Generic;

namespace Concessionaria.Web.Application.Email
{
    public class EmailApplication : BaseApplication
    {
        public EmailApplication() : base($"http://localhost:51169/api/email")
        {
        }
        public Response Post(EmailModel email)
        {
            return Request.Post(email).AsResponse();
        }
        public Response Delete(int id)
        {
            return Request.Delete(id).AsResponse();
        }
        public Response<IEnumerable<EmailModel>> GetEmails() =>
          Request.Get("todos").AsResponse<IEnumerable<EmailModel>>();
        public Response<IEnumerable<EmailModel>> GetEmail(int id) =>
           Request.Get($"{id}").AsResponse<IEnumerable<EmailModel>>();
    }
}
