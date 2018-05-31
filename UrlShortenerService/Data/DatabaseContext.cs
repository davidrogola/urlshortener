using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UrlShortenerService.Models;

namespace UrlShortenerService.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("UrlShortenerDatabase")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DatabaseContext>());
        }

        public DbSet<GeneratedShortUrl> GeneratedShortUrls { get; set; }
    }
}