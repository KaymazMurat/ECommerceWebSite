using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MKaymaz_ECommerce.Web.UI.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "İsim girmek zorunludur")]
        [Display(Name = "İsim")]
        public string FirstName{ get; set; }

        [Required(ErrorMessage = "Soy İsim girmek zorunludur")]
        [Display(Name = "Soyisim")]
        public string SurName{ get; set; } 
        

        [Required(ErrorMessage = "E-Posra adresi girmek zorunludur")]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre girmek zorunludur")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Şifre eşleşmedi Tekrar deneyiniz!!!")]
        public string ConfirmPassword { get; set; }
    }
}
