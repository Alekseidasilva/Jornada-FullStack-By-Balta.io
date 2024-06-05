public partial class CreateCategoryPage : ComponentBase
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
            var response = await Handler.CreateAsync(InputModel);
            if (response.IsSucceeded)
            {
                Snackbar.Add("Category created successfully", Severity.Success);
                NavigationManager.NavigateTo("/categorias");
            }
            else
            {
                Snackbar.Add(response.Message, Severity.Error);
            }
        }
        catch (Exception e)
        {
            Snackbar.Add(e.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }
    #endregion

}