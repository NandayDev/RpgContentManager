using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RpgContentManager.WebApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgContentManager.WebApp.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
            EnsureInitialized();
        }

        #region Initialization

        private static bool _initialized = false;

        private void EnsureInitialized()
        {
            if (!_initialized)
            {
                _initialized = true;
                Database.EnsureCreated();
                Database.Migrate();
            }
        }

        #endregion
    }
}
