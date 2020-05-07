using System;
using SportEvent.Core;
using System.Data;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace SportEvent.DataAccesLayer
{
    public class SportEventContext:DbContext
    {
        public SportEventContext() : base("DbEvent")
        {
        }

        public DbSet<Event> Events { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

       // public System.Data.Entity.DbSet<SportEvent.Core.Output.SportEventOutput> SportEventOutputs { get; set; }
    }
}
