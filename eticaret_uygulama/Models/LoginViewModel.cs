using System.ComponentModel.DataAnnotations;

namespace eticaret_uygulama.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre girilmesi zorunludur.")]
        public string Password { get; set; }
    }
}