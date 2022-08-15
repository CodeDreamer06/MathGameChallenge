using Microsoft.EntityFrameworkCore;

namespace MathGameChallenge;

class HistoryContext : DbContext
{
    public DbSet<HistoryRecord> History => Set<HistoryRecord>();

    public HistoryContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source=mathGame.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HistoryRecord>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Date);
            entity.Property(e => e.Score).IsRequired();
            entity.Property(e => e.GameType).IsRequired();
        });
    }
}