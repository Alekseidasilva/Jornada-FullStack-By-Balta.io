using System.Net.Http.Json;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;

namespace Fina.Web.Handler;

public class CategoryHandler(IHttpClientFactory httpClientFactory):ICategoryHandler
{
    private readonly HttpClient _client=httpClientFactory.CreateClient();
    public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        try
        {
            var result = await _client.PostAsJsonAsync("v1/categories", request);
            return await result.Content.ReadFromJsonAsync<Response<Category?>>() ?? new Response<Category?>(
                null, 400, "Falha ao criar a categoria");

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        try
        {
            var result = await _client.PutAsJsonAsync($"v1/categories/{request.Id}", request);
            return await result.Content.ReadFromJsonAsync<Response<Category?>>() ?? new Response<Category?>(
                null, 400, "Falha ao actualizar a categoria");

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        try
        {
            var result = await _client.DeleteAsync($"v1/categories/{request.Id}");
            return await result.Content.ReadFromJsonAsync<Response<Category?>>() ?? new Response<Category?>(
                null, 400, "Falha ao excluir a categoria");

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Response<Category?>> GetByIdAsync(GetByIdCategoryRequest request)
        => await _client.GetFromJsonAsync<Response<Category?>>($"v1/categories/{request.Id}") ??
           new Response<Category?>(null, 400, $"Falha ao obter categoria pelo id:{request.Id}");

    public async Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoryRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Category>?>>(request.UserId) ??
           new PagedResponse<List<Category>?>(null, 400, "Falha ao categoria paginada");
    

}









