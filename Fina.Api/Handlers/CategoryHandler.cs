using Fina.Api.Data;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Fina.Api.Handlers;

public class CategoryHandler(AppDbContext context):ICategoryHandler
{
    public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        //se quiser pode add autoMapper
        var category = new Category
        {
            UserId = request.UserId,
            Title = request.Title,
            Description = request.Description
        };
        try
        {
            await context.Categories.AddRangeAsync(category);
            await context.SaveChangesAsync();
            return new Response<Category?>(category, 201, "Categoria criada com sucesso!");
        }
        catch (Exception e)//Pode fazer tratamento de exceptiosn de formais ricas usando dbexceptions
        {
            // Aqui pode usar tb o Serilog ou Telemetry
            
            return new Response<Category?>(null, 500, "Nao foi possivel criar a categoria!");
        }
    }

    public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
       //Primeiro fazer o processo de reidratacao
       //que e obter a a categoria do Banco e ver se ela existe
       try
       {

           var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id
               && x.UserId==request.UserId, CancellationToken.None);
           if (category is null)
               return new Response<Category?>(null, 404, "Categoria nao encontrada");
           category.Title = request.Title;
           category.Description = request.Description;

           context.Categories.Update(category);
           await context.SaveChangesAsync();

           return new Response<Category?>(category, message: "Categoria atualizada com Sucesso!");

       }
       catch (Exception e)
       {
           return new Response<Category?>(null,500,  "Nao foi Possivel actualizar a cattegoria!");
       }
    }

    public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        try
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => 
                x.Id == request.Id && 
                x.UserId==request.UserId, CancellationToken.None);
            if (category is null)
                return new Response<Category?>(null, 404, "Categoria nao encontrada");
            
            context.Categories.Remove(category);
            await context.SaveChangesAsync();

            return new Response<Category?>(category, message: "Categoria removida com Sucesso!");

        }
        catch (Exception e)
        {
            return new Response<Category?>(null,500,  "Nao foi Possivel remover a cattegorio!");
        }
    }

    public async Task<Response<Category?>> GetByIdAsync(GetByIdCategoryRequest request)
    {
        try
        {
            var category = await context
                .Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x
                                              .Id == request.Id && x
                    .UserId==request.UserId, CancellationToken.None);

            return category is null?
                new Response<Category?>(null, 404, "Categoria nao encontrada")
                :new Response<Category?>(category);
            
            
        }
        catch (Exception e)
        {
            return new Response<Category?>(null,500,  "Nao foi Possivel recuperar a cattegorio!");
        }
    }

    public async Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoryRequest request)
    {
        try
        {
            //Count
            var query = context
                .Categories
                .AsNoTracking()
                .Where(x => x.UserId == request.UserId)
                .OrderBy(x => x.Title);

            var categories = await query
                .Skip(request.PageNumber * request.PageSize) //Paginacao
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Category>?>(
                categories,
                count,
                request.PageNumber,
                request.PageSize
            );
        }
        catch (Exception e)
        {
            return new PagedResponse<List<Category>?>(null,500,  "Nao foi Possivel recuperar a cattegorio!");
        }
    }
}