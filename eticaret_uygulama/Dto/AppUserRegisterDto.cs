using System.ComponentModel.DataAnnotations;

namespace eticaret_uygulama.Dto
{
    public class AppUserRegisterDto
    {
        [Display(Name ="Adınız")]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz.")]
        public string FirstName { get; set; }
        [Display(Name = "Soyadınızı Giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string LastName { get; set; }
        [Display(Name = "Kullanıcı Adınızı Giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string UserName { get; set; }
        [Display(Name = "Şehir Giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string City { get; set; }
        [Display(Name = "Email Adresinizi Giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string Email { get; set; }
        [Display(Name = "Telefon Numaranızı Giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Şifrenizi Giriniz")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
