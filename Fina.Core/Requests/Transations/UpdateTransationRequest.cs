using System.ComponentModel.DataAnnotations;
using Fina.Core.Enums;

namespace Fina.Core.Requests.Transations;

public class UpdateTransationRequest:Request
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Titulo Invalido")]
    [MaxLength(80,ErrorMessage = "O Titulo deve conter ate 80 Caracteres")]
    public string Title { get; set; }=String.Empty;

    [Required(ErrorMessage = "Tipo Invalido")]
    public ETransationType Type { get; set; } = ETransationType.Withdraw;

    [Required(ErrorMessage = "Valor Invalido")]
    public decimal Amonut { get; set; } 
    
    [Required(ErrorMessage = "Categoria Invalida")]
    public long CategoryId { get; set; } 
    
    [Required(ErrorMessage = "Data Invalida")]
    public DateTime? PaidOrReceivedAt { get; set; } 
}