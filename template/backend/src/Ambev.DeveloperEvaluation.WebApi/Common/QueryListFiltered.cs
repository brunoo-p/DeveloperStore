namespace Ambev.DeveloperEvaluation.WebApi.Common;

public class QueryListFiltered
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? OrderBy { get; set; }
}
