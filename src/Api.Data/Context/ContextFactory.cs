using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
  public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
  {
    public MyContext CreateDbContext(string[] args)
    {
      // Usado para criar as Migrações
      // MySql
      var connectionString = "Server=localhost;Port=3306;Database=Course;Uid=root;Pwd=root;";
      // SQLServer
      // var connectionString = "Server=127.0.0.1,1433;Database=Course;User Id=SA;Password=Pa$$w0rd";
      // optionsBuilder.UseSqlServer(connectionString);
      var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
      optionsBuilder.UseMySql(connectionString);
      return new MyContext(optionsBuilder.Options);
    }
  }
}
