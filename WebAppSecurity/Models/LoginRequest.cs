using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAppSecurity.Models
{
	public class LoginRequest
	{
		[DisplayName("User Name")]
		[Required]
		public string UserName { get; set; }

		[Required]
		public string Password { get; set; }

		public bool RememberMe { get; set; }
	}
}
