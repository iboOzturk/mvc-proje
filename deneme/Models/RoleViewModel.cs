using System.ComponentModel.DataAnnotations;

namespace deneme.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Lütfen Rol Adı Giriniz")]
        public string name { get; set; }
    }
}
