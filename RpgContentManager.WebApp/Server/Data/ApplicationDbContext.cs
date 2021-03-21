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
            EnsureMigrated();
        }

        #region Db sets

        public DbSet<Actor> Actors { get; set; }

        #endregion

        #region Migration

        private static bool _migrated = false;

        private void EnsureMigrated()
        {
            if (!_migrated)
            {
                _migrated = true;
                Database.Migrate();
            }
        }

        #endregion
    }
}
