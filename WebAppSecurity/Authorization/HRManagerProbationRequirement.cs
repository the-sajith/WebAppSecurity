using Microsoft.AspNetCore.Authorization;

namespace WebAppSecurity.Authorization
{
	public class HRManagerProbationRequirement : IAuthorizationRequirement
	{
		public int ProbationMonths { get; set; }

		public HRManagerProbationRequirement(int probationMonths)
		{
			ProbationMonths = probationMonths;
		}
	}
}
