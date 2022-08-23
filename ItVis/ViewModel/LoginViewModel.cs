using System.ComponentModel.DataAnnotations;

namespace ItVis.ViewModel.RegisterModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Не указан номер телефона")]
        [StringLength(12, MinimumLength = 10, ErrorMessage = "Некорректный номер телефона")]
        [RegularExpression(@"^(\+7)[0-9]{3}[0-9]{3}[0-9]{2}[0-9]{2}", ErrorMessage = "Номер телефона должен начинаться с +7")]
        public string Phone { get; set; } = null!;
        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Пароль слишком короткий")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Некорректный пароль")]
        public string Password { get; set; } = null!;
    }
}
