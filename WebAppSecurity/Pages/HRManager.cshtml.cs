using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppSecurity.Pages
{
    [Authorize("HRManager")]
    public class HRManagerModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
