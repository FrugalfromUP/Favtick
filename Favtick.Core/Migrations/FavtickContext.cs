using Favtick.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Favtick.Core.Migrations
{
    public class FavtickContext : DbContext
    {
        //private readonly IConfiguration _configuration;
        //private readonly string _connectionString;

        //public FavtickContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //    _connectionString = _configuration.GetConnectionString("default");

        //}

        //DbSet<Condidate> condidates { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql(ServerVersion.AutoDetect("_connectionString"));
        //}

        public FavtickContext(DbContextOptions options) : base(options) { }

        public DbSet<Condidate> Condidates { get; set; }

         //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql(ServerVersion.AutoDetect("_connectionString"));
        //}

    }
}
