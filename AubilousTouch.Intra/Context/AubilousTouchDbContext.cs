using AubilousTouch.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AubilousTouch.Intra.Context
{
    public class AubilousTouchDbContext : DbContext
    {
        public AubilousTouchDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<MessagesChannel> MessagesChannel { get; set; }
        public DbSet<MessagesChannelPerEmployee> MessagesChannelPerEmployee { get; set; }
        public DbSet<MessagesGroup> MessagesGroup { get; set; }
        public DbSet<MessagesGroupPerEmployee> MessagesGroupPerEmployee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Conforme necessário
        }
    }
}
