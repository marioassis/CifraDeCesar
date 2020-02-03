using Newtonsoft.Json;
using System;
using System.IO;
using Codenation.Negocios.Entidades;

namespace Codenation.Negocios.Metodos
{
    public class Arquivos
    {
        public static Answer CriarArquivoJson(Answer answer)
        {
            var jsonSerializado = JsonConvert.SerializeObject(answer);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "answer.json", jsonSerializado);
            return LerArquivoJson();
        }

        public static Answer LerArquivoJson()
        {
            var json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "answer.json");
            var answer = JsonConvert.DeserializeObject<Answer>(json);
            return answer;
        }
    }
}