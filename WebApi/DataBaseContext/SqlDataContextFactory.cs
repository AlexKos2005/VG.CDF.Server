using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace VG.CDF.Server.WebApi.DataBaseContext;

public class SqlDataContextFactory : IDesignTimeDbContextFactory<SqlDataContext>
{
    public SqlDataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SqlDataContext>();
        optionsBuilder.UseNpgsql("Host=89.44.197.196;Port=5432;Database=volgor_asud_new;Username=postgres;Password=!PGadmin!;");
        /*var optionsBuilder = new DbContextOptionsBuilder<SqlDataContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=volgor_asud_new;Username=postgres;Password=sa;");*/

        return new SqlDataContext(optionsBuilder.Options);
    }
}