namespace CrashCourseWeb.Helpers;
public class Pagination
{

}

public abstract class PagedResultBase
{
    public int CurrentPage { get; set; }
    public int RecordsPerPage { get; set; }
    public int RecordCount { get; set; }
    public int TotalPages { get; set; }
    public string? PreviousPage { get; set; }
    public string? NextPage { get; set; }
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public string? Code { get; set; }
}