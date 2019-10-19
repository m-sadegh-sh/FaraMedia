namespace FaraMedia.Services.Extensions.Security {
    using System;
    using System.Linq;

    using FaraMedia.Core;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Domain.Security;
    using FaraMedia.Core.Domain.Shared;
    using FaraMedia.Core.Domain.Systematic;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Knowns;
    using FaraMedia.Data.Knowns.Security;
    using FaraMedia.Data.Schemas.Layout;
    using FaraMedia.Services.Extensions.Shared;
    using FaraMedia.Services.Extensions.Systematic;
    using FaraMedia.Services.Querying.Shared;
    using FaraMedia.Services.Querying.Systematic;

    public static class UserExtentions {
        public static bool IsAdmin(this User user, bool onlyActiveUserRoles = true) {
            return IsInUserRole(user, RoleNames.Administrators, onlyActiveUserRoles);
        }

        public static bool IsRegistered(this User user, bool onlyActiveUserRoles = true) {
            return IsInUserRole(user, RoleNames.Registered, onlyActiveUserRoles);
        }

        public static bool IsGuest(this User user, bool onlyActiveUserRoles = true) {
            return IsInUserRole(user, RoleNames.Guests, onlyActiveUserRoles);
        }

        public static bool IsInUserRole(this User user, string roleSystemName, bool onlyActiveUserRoles = true) {
            if (user == null)
                throw new ArgumentNullException("user");

            if (user.IsTransient())
                return false;

            if (string.IsNullOrEmpty(roleSystemName))
                throw new ArgumentNullException("roleSystemName");

            var isInRole = user.Roles.Where(r => !onlyActiveUserRoles || (r.IsActive)).FirstOrDefault(r => r.SystemName == roleSystemName) != null;

            return isInRole;
        }

        public static bool IsSearchEngineAccount(this User user) {
            if (user == null)
                throw new ArgumentNullException("user");

            if (Neutrals.Is(user.SystemName))
                return false;

            var result = user.SystemName.Equals(UserNames.SearchEngine, StringComparison.InvariantCultureIgnoreCase);

            return result;
        }

        public static string GetFullName(this User user) {
            if (user == null)
                throw new ArgumentNullException("user");

            var entityAttributeService = EngineContext.Current.Resolve<IDbService<EntityAttribute, EntityAttributeQuery>>();

            var firstName = entityAttributeService.GetValueByOwnerIdAndKey(user.Id, UserAttributeNames.FirstName, "");
            var lastName = entityAttributeService.GetValueByOwnerIdAndKey(user.Id, UserAttributeNames.LastName, "");

            var fullName = string.Empty;

            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
                fullName = string.Format("{0} {1}", firstName, lastName);
            else {
                if (!string.IsNullOrWhiteSpace(firstName))
                    fullName = firstName;

                if (!string.IsNullOrWhiteSpace(lastName))
                    fullName = lastName;
            }

            return fullName;
        }

        public static string FormatUserName(this User user) {
            var result = string.Empty;

            if (user == null)
                return result;

            if (user.IsGuest()) {
                var resourceValueService = EngineContext.Current.Resolve<IDbService<ResourceValue, ResourceValueQuery>>();

                result = resourceValueService.GetValueByKey(PartialsConstants.Auth.Labels.Anonymous);

                return result;
            }

            var securitySettings = EngineContext.Current.Resolve<SecuritySettings>();

            switch (securitySettings.ScreenNameFormat) {
                case DisplayScreenNameFormat.Email:
                    result = user.Email;
                    break;
                case DisplayScreenNameFormat.UserName:
                    result = user.UserName;
                    break;
                case DisplayScreenNameFormat.FullName:
                    result = user.GetFullName();
                    break;
            }

            return result;
        }
    }
}