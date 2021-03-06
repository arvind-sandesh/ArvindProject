using Arvind.Entities.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Arvind.WebApp.Factory
{
    public class CustomClaimsFactory : UserClaimsPrincipalFactory<AppUser>
    {
        public CustomClaimsFactory(UserManager<AppUser> userManager, IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, optionsAccessor)
        { }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
        {
            //return base.GenerateClaimsAsync(user);
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("fullname", user.FullName));

            var roles = await UserManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            return identity;
        }
    }
}
