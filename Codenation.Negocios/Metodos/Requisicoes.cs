using System.Configuration;
using Codenation.Negocios.Entidades;
using Newtonsoft.Json;
using RestSharp;
using System.IO;
using System.Net;
using System.Text;

namespace Codenation.Negocios.Metodos
{
    public class Requisicoes
    {
        public static Answer GetAnswer()
        {
            string token = ConfigurationManager.AppSettings["TokenCodenation"];
            var requisicao = WebRequest.CreateHttp("https://api.codenation.dev/v1/challenge/dev-ps/generate-data?token=" + token);
            Answer answer = new Answer();
            requisicao.Method = "GET";
            requisicao.UserAgent = "GetJsonCodenation";
            using (var resposta = requisicao.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<Answer>(objResponse.ToString());
                streamDados.Close();
                resposta.Close();
            }
            return Arquivos.CriarArquivoJson(answer);
        }

        public static IRestResponse PostAnswer()
        {
            Answer answer = Arquivos.LerArquivoJson();
            var postData = JsonConvert.SerializeObject(answer);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            var client = new RestClient("https://api.codenation.dev/v1/challenge/dev-ps/submit-solution?token=" + answer.Token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "multipart/form-data");
            request.AddFileBytes("answer", byteArray, "answer.json", "application/json");
            IRestResponse response = client.Execute(request);

            return response;
        }
    }
}