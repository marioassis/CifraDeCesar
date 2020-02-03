using Codenation.Negocios.Entidades;
using Codenation.Negocios.Metodos;
using Codenation.Web.Models;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace Codenation.Web.Controllers
{
    public class AtualizadoController : Controller
    {
        public ActionResult Index()
        {
            var retorno = Arquivos.LerArquivoJson();
            retorno = Seguranca.DecifraDeCesar(retorno);
            retorno = Seguranca.CriptografarSha1(retorno);
            Arquivos.CriarArquivoJson(retorno);
            Answer model = new Answer(retorno.Numero_casas, retorno.Token, retorno.Cifrado, retorno.Decifrado, retorno.Resumo_criptografico);
            return View(model);
        }

        [HttpPost]
        public ActionResult EnviarArquivoJson()
        {
            var response = Requisicoes.PostAnswer();
            var responseCodenation = new ResponseCodenation(response.StatusCode.ToString(), response.StatusDescription, response.ResponseStatus.ToString(), response.IsSuccessful.ToString(), JsonConvert.DeserializeObject<ScoreContent>(response.Content));
            return PartialView("_responseCodenation", responseCodenation);
        }
    }
}