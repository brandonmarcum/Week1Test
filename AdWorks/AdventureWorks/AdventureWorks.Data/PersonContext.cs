using AdventureWorks.Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace AdventureWorks.Data
{
  public class PersonContext : DbContext
  {
    public IConfiguration Configuration {get; set;}
    public DbSet<Person> Persons { get; set;}

    public PersonContext()
    {
      Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.dev.json").Build();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(Configuration.GetSection("connectionstring").Value);
    }
  }
}
