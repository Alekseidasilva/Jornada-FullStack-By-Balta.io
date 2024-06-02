using Fina.Core.Enums;

namespace Fina.Core.Models;

public class Transation
{
    public long Id { get; set; }
    public string Title { get; set; }=String.Empty;

    public DateTime CreatedAt { get; set; }=DateTime.Now;
    public DateTime? PaidOrreceivedAt { get; set; }
    public decimal Amonut { get; set; } 
    public ETransationType Type { get; set; } = ETransationType.Withdraw;
    public long CategoryId { get; set; }
    public string UserId { get; set; }=String.Empty;
}