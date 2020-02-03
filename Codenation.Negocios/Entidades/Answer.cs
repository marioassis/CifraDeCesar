namespace Codenation.Negocios.Entidades
{
    public class Answer
    {
        public int Numero_casas { get; set; }
        public string Token { get; set; }
        public string Cifrado { get; set; }
        public string Decifrado { get; set; }
        public string Resumo_criptografico { get; set; }

        public Answer() { }

        public Answer(int numero_casas, string token, string cifrado, string decifrado, string resumo_criptografico)
        {
            Numero_casas = numero_casas;
            Token = token;
            Cifrado = cifrado;
            Decifrado = decifrado;
            Resumo_criptografico = resumo_criptografico;
        }
    }
}