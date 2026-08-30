using Microsoft.EntityFrameworkCore;

namespace webApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
{
    public DbSet<model.Character> Characters => Set<model.Character>();
}
