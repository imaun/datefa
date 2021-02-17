using Microsoft.EntityFrameworkCore;
using Datefa.Data.Models;

namespace Datefa.Data.Internal {

    internal class DatefaDb: DbContext {

        private const string _connectionString = @"Data Source=datefa.db;UseUTF8Encoding=True";

        internal DatefaDb() {
            
        }

        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlite(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddCalendarMapping();
            modelBuilder.AddEventMapping();
        }
    }
}
