using System.ComponentModel.DataAnnotations;

namespace WebBlog.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Inform o e-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Informe a senha")]
    public string Password { get; set; }
}