namespace Fina.Api;

public static class ApiConfiguration
{
    public const string UserId = "Jornada@Balta.ao";
    public const int DefaultPageNumber = 1;
    public const int DefaultPageSize = 25;
    public static string ConnectionString { get; set; } = string.Empty;

    public static string CorsPolicyName = "wasm";
}