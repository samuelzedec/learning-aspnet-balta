using System.ComponentModel.DataAnnotations;

namespace WebBlog.ViewModels.Accounts;

public class RegisterViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "O e-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "O e-mail é inválido")] // Verifica se o formato é valido
    public string Email { get; set; }
    
    
    
}