using System.ComponentModel.DataAnnotations;

namespace deneme.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Giriniz")]
        public string username { get; set; }

        [Required(ErrorMessage ="Lütfen Şifre Giriniz")]
        public string password { get; set; }
    }
}
