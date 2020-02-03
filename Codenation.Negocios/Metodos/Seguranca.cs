using Codenation.Negocios.Entidades;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Codenation.Negocios.Metodos
{
    public class Seguranca
    {
        public static Answer DecifraDeCesar(Answer answer)
        {
            int i, caracter;
            answer.Decifrado = "";
            for (i = 0; i < answer.Cifrado.Length; i++)
            {
                caracter = Convert.ToInt32(answer.Cifrado[i]);
                if (caracter >= 97 && caracter <= 122)
                {
                    caracter = Convert.ToInt32(answer.Cifrado[i]) - answer.Numero_casas;
                    if (caracter < 97) caracter = caracter + 26;
                    answer.Decifrado += Convert.ToChar(caracter);
                }
                else
                {
                    answer.Decifrado += Convert.ToChar(caracter);
                }
            }
            return answer;
        }

        public static Answer CriptografarSha1(Answer answer)
        {
            byte[] buffer = Encoding.Default.GetBytes(answer.Decifrado);
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
            string sha1 = BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
            answer.Resumo_criptografico = sha1.ToLower();

            return answer;
        }
    }
}