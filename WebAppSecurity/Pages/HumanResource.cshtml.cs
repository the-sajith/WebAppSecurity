using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppSecurity.Pages
{
    [Authorize(Policy = "HRPolicy")]
    public class HumanResourceModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
