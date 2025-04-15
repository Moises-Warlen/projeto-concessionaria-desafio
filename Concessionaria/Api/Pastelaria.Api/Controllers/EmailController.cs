using Concessionaria.Api.Infra.Configuration;
using Concessionaria.Domain.Email;
using System.Web.Http;

namespace Concessionaria.Api.Controllers
{

    [RoutePrefix("api/email")]
    public class EmailController : AuthApiController
    {
        private readonly IEmailRepository _emailRepository;

        public EmailController(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        // Endpoint para obter emails de um usuário específico baseado no ID do email.
        [HttpGet, Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var email = _emailRepository.GetId(id); // Obtém a lista de emails para o ID fornecido.
            return Ok(email); // Retorna a lista de Email com um código de status HTTP 200 (OK).
        }

        //Endpoint para deletar um email baseado no ID do email.

       [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            _emailRepository.DeleteEmailCliente(id); // Deleta o email com o ID fornecido.

            return Ok(); // Retorna um código de status HTTP 200 (OK) indicando que a operação foi bem-sucedida.
        }

    }
}