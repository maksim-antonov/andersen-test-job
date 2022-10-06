using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilmsTestJob.Pages;

public class IndexModel : PageModel
{
    public IActionResult OnGet()
    {
        return Page();
    }
}