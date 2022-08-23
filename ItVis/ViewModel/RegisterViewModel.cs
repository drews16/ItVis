using System.ComponentModel.DataAnnotations;

namespace ItVis.ViewModel
{ 
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Не указано имя")]
        [RegularExpression(@"^[a-zA-Zа-яА-Я]+$", ErrorMessage = "Некорректное имя")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Некорректное имя")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Введите номер телефона")]
        [StringLength(12, MinimumLength = 11, ErrorMessage = "Некорректный номера телефона")]
        [RegularExpression(@"^(\+7)[0-9]{3}[0-9]{3}[0-9]{2}[0-9]{2}", ErrorMessage = "Некорректный номер телефона")]
        public string Phone { get; set; } = null!;
        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Пароль слишком короткий")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Некорректный пароль")]
        public string Password { get; set; } = null!;
    }
}
