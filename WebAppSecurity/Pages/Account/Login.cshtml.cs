using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppSecurity.Models;

namespace WebAppSecurity.Pages.Account
{
	public class LoginModel : PageModel
	{
		[BindProperty]
		public LoginRequest NewLoginRequest { get; set; }

		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}


			//Here we are using Cookie Based Authentication. Cookies are associated with a specific domain.
			if (NewLoginRequest.UserName == "admin" && NewLoginRequest.Password == "password")
			{
				var claims = new List<Claim>()
				{   new Claim(ClaimTypes.Name, "admin"),
					new Claim(ClaimTypes.Email, "admin@bristo.co"),
					new Claim("HR", "true"),
					new Claim("Admin", "true"),
					new Claim("Manager", "true"),
					new Claim("EmploymentDate", "12-12-2022"),
				};

				var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

				//ClaimsPrincipal is the user. As in real world, user has different identities. For Example, Drivers License, Voter Card etc.
				// Similary claims principal has different identities. Each of the identity can contain a list of claims like in case
				// of License, user's name, address, expiry date etc. 
				ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

				var authProperties = new AuthenticationProperties()
				{
					IsPersistent = NewLoginRequest.RememberMe,

				};

				//SignInAsyc will take the claimsPrincipal and use encryption to convert the info in claims to a security context
				// in the form a cookie here.
				// Each time when the user access a page, the server will decrypt the security context and check if it is a valid user.
				// This is done by AuthenticationHandler in the startup/or program in this case.
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);

				return Redirect("/Index");

			}



			return Page();
		}
	}
}
