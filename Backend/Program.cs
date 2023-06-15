global using BusinessLogic.Entities;
using Backend.Services.UtilizadorService;
using BusinessLogic.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var myAllowSpecificOrigins = "_myAllowSpecifcOrigins";

builder.Services.AddCors(options=>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy=>{
            policy. WithOrigins ("http://localhost:5070" )
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
}); 

/*builder.Services.AddCors(options=>
{
    options.AddDefaultPolicy(
        policy=>
        {
            policy.WithOrigins("http://localhost:5070");
        });
}); */

/*builder.Services.AddCors(options=>
{
    options.AddPolicy("myAllowSpecificOrigins",
        policy=>
        {
            policy.WithOrigins("http://localhost:5070")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
}); */

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUtilizadorService, UtilizadorService>();

/*builder.Services.AddCors();*/

/*builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:5052")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});*/


// Add default connection string for the Web API controllers
builder.Services.AddDbContext<TarefasDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("myAllowSpecificOrigins");
//app.UseCors();
app.UseRouting();
// Inside the Configure method in your backend code
/*app.UseCors(options =>
{
    options.WithOrigins("http://localhost:5270")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
});*/

app.UseAuthorization();

/*app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/api/Utilizador",
            context => context.Response.WriteAsync("/api/Utilizador"))
        .RequireCors(myAllowSpecificOrigins);
    
    endpoints.MapControllers()
        .RequireCors(myAllowSpecificOrigins);

    endpoints.MapRazorPages();
});*/

/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});*/

app.MapControllers();

app.Run();