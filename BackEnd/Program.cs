using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using BackEnd.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(ob => ob.EnableEndpointRouting = false);
builder.Services.AddDbContext<Context>();
builder.Services.AddCors();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MapDefaultControllerRoute();
app.UseCors(ob =>
{
    ob.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
});


app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();