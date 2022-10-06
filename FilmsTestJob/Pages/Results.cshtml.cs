using FilmsTestJob.Services;
using FilmTestJob.Entities.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmsTestJob.Pages;

public class ResultsModel : PageModel
{
    private readonly SearchService _service;

    public ResultsModel(SearchService service)
    {
        _service = service;
    }

    public IList<SearchResult> Films { get; set; } = new List<SearchResult>();
    public string ErrorMessage;
    public string QueryText;

    public async Task OnGetAsync(string title)
    {
        var data = await _service.SearchAsync(title);

        if (!string.IsNullOrWhiteSpace(data.ErrorMessage))
        {
            ErrorMessage = data.ErrorMessage;
            QueryText = data.Expression;
            return;
        }

        Films = data.Results;
    }
}