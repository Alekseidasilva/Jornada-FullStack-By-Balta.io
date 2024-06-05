﻿using Fina.Core.Handlers;
using Fina.Core.Requests.Categories;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Fina.Web.Pages.Categories;

public partial class CreateCategoryPage:ComponentBase
{
    #region Properties
    public bool IsBusy { get; set; } = false;
    public CreateCategoryRequest InputModel { get; set; } = new CreateCategoryRequest();
    #endregion
    #region Injects
    [Inject]
    private ICategoryHandler Handler { get; set; } = null!;
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    #endregion
    #region Methods
    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;
        try
        {
            var result = await Handler.CreateAsync(InputModel);
            if (result.IsSuccess)
            {
                Snackbar.Add("Category created successfully", Severity.Success);
                NavigationManager.NavigateTo("/categorias");
            }
            else
            {
                Snackbar.Add(result.Message, Severity.Error);
            }
        }
        catch (Exception e)
        {
            Snackbar.Add("Erro: "+e.Message, Severity.Warning);
            
        }
        finally
        {
            IsBusy = false;
        }
    }
    #endregion
}