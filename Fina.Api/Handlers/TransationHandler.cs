using Fina.Api.Data;
using Fina.Core.Common;
using Fina.Core.Enums;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transations;
using Fina.Core.Responses;
using Microsoft.EntityFrameworkCore;

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
        if (request is { Type: ETransationType.Withdraw, Amonut:>=0})
            request.Amonut *= -1;
        try
        {
          var transation =await context.Transations.FirstOrDefaultAsync(x => x
              .Id == request.Id && x.UserId == request.UserId);
          if (transation is null)
              return new Response<Transation?>(null, 404, "Transacao Nao Transation");
          transation.CategoryId = request.CategoryId;
          transation.Amonut = request.Amonut;
          transation.Title = request.Title;
          transation.Type = request.Type;
          transation.PaidOrreceivedAt = request.PaidOrReceivedAt;

         context.Transations.Update(transation);
         await context.SaveChangesAsync();

         return new Response<Transation?>(transation);

        }
        catch (Exception e)
        {
            return new Response<Transation?>(null, 500,"Nao foi possivel actualizar a transacao");
        }
        
    }

    public async Task<Response<Transation?>> DeleteAsync(DeleteTransationRequest request)
    {
        try
        {
            var transation = await context
                .Transations
                .FirstOrDefaultAsync(x => x.Id == request.Id
                                          && x.UserId == request.UserId);
            if (transation is null)
                return new Response<Transation?>(null, 404, "Transacao Nao Transation");

            context.Transations.Remove(transation);
            await context.SaveChangesAsync();

            return new Response<Transation?>(transation);
        }
        catch (Exception e)
        {
            return new Response<Transation?>(null, 500,$"Nao foi possivel actualizar a transacao: {e.Message}");
        }
    }

    public async Task<Response<Transation?>> GetByIdAsync(GetByIdTransationRequest request)
    {
        try
        {
            var transation = await context
                .Transations
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId==request.UserId, CancellationToken.None);

            return transation is null?
                new Response<Transation?>(null, 404, "Categoria nao encontrada")
                :new Response<Transation?>(transation);
        }
        catch (Exception e)
        {
            return new Response<Transation?>(null, 500,$"Nao foi possivel actualizar a transacao: {e.Message}");
        }
    }

    public async Task<PagedResponse<List<Transation>?>> GetByPeriodAsync(GetTransationByPeriodRequest request)
    {
        try
        {
            request.StartDate??=DateTime.Now.GetFirstDayOfMonth();
            request.EndDate??=DateTime.Now.GetLastDayOfMonth();
            
        }
        catch (Exception e)
        {
            return new PagedResponse<List<Transation>?>(null,500,"Nao foi possivel determinar");
        }

        try
        {
            var query = context.Transations.AsNoTracking()
                .Where(x => x.PaidOrreceivedAt >= request.StartDate &&
                            x.PaidOrreceivedAt <= request.EndDate &&
                            x.UserId == request.UserId)
                .OrderBy(x => x.PaidOrreceivedAt);

            var transation = await query.Skip(request.PageNumber)
                .Take(request.PageSize-1*request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Transation>?>(transation, count, request.PageNumber, request.PageSize);

        }
        catch (Exception e)
        {
            return new PagedResponse<List<Transation>?>(null,500,"Nao foi possivel determinar");
        }
    }
}

















