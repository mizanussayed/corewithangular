using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services;
public class Context : DbContext
{
    public DbSet<Member> Member { get; set; }
    public DbSet<Session> Session { get; set; }
    public DbSet<Purchage> purchage { get; set; }
    public DbSet<FundCollection> FundCollection { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb; database=MvcAngularDb; integrated security= true;");
    }
}
