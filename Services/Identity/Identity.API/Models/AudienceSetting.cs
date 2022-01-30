namespace Identity.API.Models
{
    public class AudienceSetting
    {
        public string Secret { get; set; }
        public string Iss { get; set; }
        public string Aud { get; set; }
    }
}
