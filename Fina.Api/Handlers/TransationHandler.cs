using Fina.Api.Data;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transations;
using Fina.Core.Responses;

namespace Fina.Api.Handlers;

public class TransationHandler(AppDbContext context):ITransationHandler
{
    public async Task<Response<Transation?>> CreateAsync(CreateTransationRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Transation?>> UpdateAsync(UpdateTransationRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Transation?>> DeleteAsync(DeleteTransationRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Transation?>> GetByIdAsync(GetByIdTransationRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResponse<List<Transation>?>> GetByPeriodAsync(GetTransationByPeriodRequest request)
    {
        throw new NotImplementedException();
    }
}