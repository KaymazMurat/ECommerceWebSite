namespace MKaymaz_ECommerce.Common.Models
{
    public class GetAcceessTokenDto
    {
        public string TokenType { get; set; } // Token Tipi
        public string AccessToken { get; set; } // Token
        public long Expires { get; set; } // Ne zaman dolacak
        public string RefreshToken { get; set; } //
    }
}
