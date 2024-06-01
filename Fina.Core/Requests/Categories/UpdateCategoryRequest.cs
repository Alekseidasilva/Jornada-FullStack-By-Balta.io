using System.ComponentModel.DataAnnotations;

namespace Fina.Core.Requests.Categories;

public class UpdateCategoryRequest:Request
{
    public long Id { get; set; }
    
    [Required(ErrorMessage = "Titulo Invalido")]
    [MaxLength(80,ErrorMessage = "O Titulo deve conter ate 80 Caracteres")]
    public string Title { get; set; }=String.Empty;
    
    [Required(ErrorMessage = "Descricao Invalido")]
    public string Description { get; set; }=String.Empty;
}