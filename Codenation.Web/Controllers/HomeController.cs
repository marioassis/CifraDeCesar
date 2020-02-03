using Codenation.Negocios.Metodos;
using System.Web.Mvc;
using Codenation.Negocios.Entidades;

namespace Codenation.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var retorno = Requisicoes.GetAnswer();
            Answer answer = new Answer(retorno.Numero_casas, retorno.Token, retorno.Cifrado, retorno.Decifrado, retorno.Resumo_criptografico);
            return View(answer);
        }
    }
}