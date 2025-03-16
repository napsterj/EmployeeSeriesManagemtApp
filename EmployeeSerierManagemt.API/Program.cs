using EmployeeSerierManagemt.API.Configurations;
using EmployeeSeriesManagemtApp.DAL.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddLogging(config =>
{
    config.ClearProviders();
    config.AddConsole();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.RegisterDependencies();
builder.AddGlobalErrorHandling();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStatusCodePages();
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

ApplyMigrations();

app.Run();

// Method that will check if any migrations are pending. If so will run them.
void ApplyMigrations()
{
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<EmployeeSeriesDbContext>();
        if (db.Database.GetPendingMigrations().Count() > 0)
        {
            db.Database.Migrate();
        }
    }
}