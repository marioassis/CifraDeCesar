namespace Codenation.Web.Models
{
    public class ResponseCodenation
    {
        public string StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string ResponseStatus { get; set; }
        public string IsSuccessful { get; set; }
        public ScoreContent Content { get; set; }

        public ResponseCodenation(string statusCode, string statusDescription, string responseStatus, string isSuccessful, ScoreContent content)
        {
            StatusCode = statusCode;
            StatusDescription = statusDescription;
            ResponseStatus = responseStatus;
            IsSuccessful = isSuccessful;
            Content = content;  
        }
    }
}