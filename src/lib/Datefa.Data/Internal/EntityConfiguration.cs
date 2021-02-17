using Microsoft.EntityFrameworkCore;
using Datefa.Data.Models;

namespace Datefa.Data.Internal {

    internal static class EntityConfiguration {

        public static void AddCalendarMapping(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<Calendar>(map => {
                map.ToTable("Calendars").HasKey(_ => _.Id);
                map.Property(_ => _.Title).HasMaxLength(255).IsRequired().IsUnicode();
                map.Property(_ => _.Name).HasMaxLength(255).IsRequired().IsUnicode();
                map.Property(_ => _.Description).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.Author).HasMaxLength(255).IsUnicode();
                map.Property(_ => _.Email).HasMaxLength(1000).IsUnicode();
                map.Property(_ => _.Website).HasMaxLength(1000).IsUnicode();
            });
        }

        public static void AddEventMapping(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<Event>(map => {
                map.ToTable("Events").HasKey(_ => _.Id);
                map.Property(_ => _.CalendarType).HasDefaultValue(CalendarType.Gregorian);
                map.Property(_ => _.Title).HasMaxLength(500).IsRequired().IsUnicode();
                map.Property(_ => _.Description).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.ImagePath).HasMaxLength(2000).IsUnicode();
                map.Property(_ => _.MoreInfoUrl).HasMaxLength(2000).IsUnicode();

                map.HasOne(_ => _.Calendar)
                    .WithMany(_ => _.Events)
                    .HasForeignKey(_ => _.CalendarId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
