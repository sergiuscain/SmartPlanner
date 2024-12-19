using System.ComponentModel.DataAnnotations;

namespace SmartPlanner.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Обязательное поле.")]
        [MinLength(5, ErrorMessage = "Логин не может быть короче 5 символов.")]
        public string UserName {  get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Пароль должен содержать минимум {2} и максимум {1} символов.", MinimumLength = 6)]
        public string Password { get; set; }
        public bool IsRememberMe { get; set; }
        //public string ReturnUrl { get; set; }
    }
}
