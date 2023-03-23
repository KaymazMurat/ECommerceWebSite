using System.ComponentModel.DataAnnotations;

namespace MKaymaz_ECommerce.Web.UI.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="E-Posra adresi girmek zorunludur")]
        [Display(Name ="E-Posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre girmek zorunludur")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

    }
}
