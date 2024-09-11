namespace JobmoonApp.Server.Extentions
{
    using JobmoonApp.Server.Data;
    using Microsoft.EntityFrameworkCore;

    public static class MigrationExtentions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();
            dbContext.Seed();

            // Test

        }
    }
}
