using Microsoft.AspNetCore.Authorization;

namespace WebAppSecurity.Authorization
{
	public class HRManagerProbationRequirementHandler : AuthorizationHandler<HRManagerProbationRequirement>
	{
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HRManagerProbationRequirement requirement)
		{
			if (!context.User.HasClaim(x => x.Type == "EmploymentDate"))
			{
				return Task.CompletedTask;
			}

			var empDate = context.User.FindFirst(x => x.Type == "EmploymentDate")
		}
	}
}
