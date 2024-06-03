using Fina.Core.Models;
using Fina.Core.Requests.Transations;
using Fina.Core.Responses;

namespace Fina.Core.Handlers;

public interface ITransationHandler
{
    Task<Response<Transation?>> CreateAsync(CreateTransationRequest request);
    Task<Response<Transation?>> UpdateAsync(UpdateTransationRequest request);
    Task<Response<Transation?>> DeleteAsync(DeleteTransationRequest request);
    Task<Response<Transation?>> GetByIdAsync(GetByIdTransationRequest request);
    Task<PagedResponse<List<Transation>?>> GetByPeriodAsync(GetTransationByPeriodRequest request);
}