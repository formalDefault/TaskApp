using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
//using Duende.IdentityServer.EntityFramework.Options;
using TaskApp.Models;

namespace TaskApp.Data;

//public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
public class ApplicationDbContext : DbContext
{
    //public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
    //    : base(options, operationalStoreOptions)
    //{

    //}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
    {

    }



    public DbSet<ApplicationUser> Users { get; set; }
}

