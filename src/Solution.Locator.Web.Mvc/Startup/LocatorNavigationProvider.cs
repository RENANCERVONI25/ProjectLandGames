using Abp.Application.Navigation;
using Abp.Localization;
using Solution.Locator.Authorization;

namespace Solution.Locator.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class LocatorNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "people",
                        requiredPermissionName: PermissionNames.Pages_Roles
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Friends,
                        L("Friends"),
                        url: "Friends",
                        icon: "people",
                        requiredPermissionName: PermissionNames.Pages_Users
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Games,
                        L("Games"),
                        url: "Games",
                        icon: "people",
                        requiredPermissionName: PermissionNames.Pages_Users
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LocatorConsts.LocalizationSourceName);
        }
    }
}
