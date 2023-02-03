using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppSecurity.Models;

namespace WebAppSecurity.Pages.Account
{
	public class LoginModel : PageModel
	{
		[BindProperty]
		public LoginRequest NewLoginRequest { get; set; }
		public LoginModel()
		{
			//        NewLoginRequest = new LoginRequest();
		}
		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			if (NewLoginRequest.UserName == "admin" && NewLoginRequest.Password == "password")
			{
				var claims = new List<Claim>()
				{   new Claim(ClaimTypes.Name, "admin"),
					new Claim(ClaimTypes.Email, "admin@bristo.co"),
					new Claim("HR", "true"),
					new Claim("Admin", "true"),
					new Claim("Manager", "true")
                };

				var identity = new ClaimsIdentity(claims, "MyAuthCookie");

				ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

				await HttpContext.SignInAsync("MyAuthCookie", claimsPrincipal);

				return Redirect("/Index");

			}



			return Page();
		}
	}
}
