using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Com.OPPO.Mo.Blogging.EntityFrameworkCore
{
    public class BloggingMigrationsDbContextFactory : IDesignTimeDbContextFactory<BloggingDbContext>
    {
        public BloggingDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<BloggingDbContext>()
                .UseSqlServer(configuration.GetConnectionString(BloggingDbProperties.ConnectionStringName));

            return new BloggingDbContext(builder.Options);
        }

        private static IConfiguration BuildConfiguration()
        {
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
