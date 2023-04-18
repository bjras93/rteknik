using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web.Http;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Models.EntityBase;
using Umbraco.Core.Models.Membership;
using Umbraco.Core.Services;
using Umbraco.Web.WebApi;
using Umbraco.Web.Security.Providers;
using System.Web.Security;

namespace rteknik 
{
    public class CreateUserController : UmbracoApiController
    {
        [HttpGet]
        public void Index()
        {
			string email = "cthian93@gmail.com";
			var newUser = Services.UserService.CreateUserWithIdentity(email, email);
			// Get user group as IReadOnlyUserGroup
			var userGroup = Services.UserService.GetUserGroupByAlias("admin") as IReadOnlyUserGroup;
			// Add the userGroup to the newUser
			newUser.AddGroup(userGroup);
			// Set the user's password
			string password = "5A2068b67C";
			newUser.RawPasswordValue = (Membership.Providers["UsersMembershipProvider"] as UsersMembershipProvider).HashPasswordForStorage(password); ;
			// Save the new user
			Services.UserService.Save(newUser);

		}

    }
}
