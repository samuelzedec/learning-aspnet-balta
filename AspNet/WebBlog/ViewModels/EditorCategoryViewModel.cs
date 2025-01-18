using System.ComponentModel.DataAnnotations;
namespace WebBlog.ViewModels;

public class EditorCategoryViewModel
{
    [Required(ErrorMessage = "Nome é requirido")]
    [StringLength(40, MinimumLength = 4, ErrorMessage = "Nome deve ter entre 3 e 40 caracteres")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Slug é requirido")]
    public string Slug { get; set; } = null!;
}