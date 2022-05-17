using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BerrasBio.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<BerrasBioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BerrasBioContext") ?? throw new InvalidOperationException("Connection string 'BerrasBioContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.

//BerrasBioContext context = app.Services.GetRequiredService<BerrasBioContext>();
//context.Database.EnsureCreated();
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var context = service.GetRequiredService<BerrasBioContext>();
    context.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
