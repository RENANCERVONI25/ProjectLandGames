using Abp.Authorization;
using Solution.Locator.Authorization.Roles;
using Solution.Locator.Authorization.Users;

namespace Solution.Locator.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
