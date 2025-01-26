using System.ComponentModel.DataAnnotations;

namespace WebBlog.ViewModels.Accounts;

public class UploadImageViewModel
{
    [Required(ErrorMessage = "Imagem inválida")]
    public string Base64Image { get; set; } = string.Empty;
}