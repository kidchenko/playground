using System;
using HotelFinder.Core;
using Microsoft.EntityFrameworkCore;

namespace HotelFinder.Web
{
    public class HotelFinderContext
    {
        public class BloggingContext : DbContext
        {
            public DbSet<Hotel> Hotels { get; set; }

            // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
            // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite(@"Data Source=C:\hotelfinder.db");
        }
    }
}