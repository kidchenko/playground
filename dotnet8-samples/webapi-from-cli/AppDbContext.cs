// generate a db context class
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppUser : IdentityUser
{
    // Add customisations here later
}

public class LeifUser : IdentityUser
{
    public int MyProperty { get; set; }
}


public class AppDbContext : IdentityDbContext<LeifUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
     : base(options)
    {
    }
}
