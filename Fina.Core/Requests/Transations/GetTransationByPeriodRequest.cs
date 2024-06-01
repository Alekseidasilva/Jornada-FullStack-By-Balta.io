namespace Fina.Core.Requests.Transations;

public class GetTransationByPeriodRequest:PagedRequest
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}