using Fina.Api.Data;
using Fina.Core.Enums;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transations;
using Fina.Core.Responses;

namespace Fina.Api.Handlers;

public class TransationHandler(AppDbContext context):ITransationHandler
{
    public async Task<Response<Transation?>> CreateAsync(CreateTransationRequest request)
    {
        if (request is { Type: ETransationType.Withdraw, Amonut:>=0})
            request.Amonut *= -1;
        try
        {
            var transation = new Transation
            {
               UserId = request.UserId,
               CategoryId = request.CategoryId,
               CreatedAt = DateTime.Now,
               Amonut = request.Amonut,
               PaidOrreceivedAt = request.PaidOrReceivedAt,
               Title = request.Title,
               Type = request.Type
            };
            await context.Transations.AddAsync(transation);
            await context.SaveChangesAsync();

            return new Response<Transation?>(transation, 201,"Transacao criada com Sucesso!");
        }
        catch (Exception e)
        {
            return new Response<Transation?>(null, 500,"Nao foi possivel criar a transacao");
        }
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