global using BusinessLogic.Entities;
using Backend.Services.UtilizadorService;
using BusinessLogic.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//var myAllowSpecificOrigins = "_myAllowSpecifcOrigins";

/*builder.Services.AddCors(options=>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy=>{
            policy. WithOrigins ("http://localhost:5052" )
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
}); */

/*builder.Services.AddCors(options=>
{
    options.AddDefaultPolicy(
        policy=>
        {
            policy.WithOrigins("http://localhost:5052");
        });
}); */

builder.Services.AddCors(options=>
{
    options.AddPolicy("myAllowSpecificOrigins",
        policy=>
        {
            policy.WithOrigins("http://localhost:5070")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
}); 

// Add services to the container.

//teste frontend
//builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages();
//builder.UseBlazorWebAssemblyAot();
//


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
/*builder.Services.AddDbContext<ES2DbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection"))
);*/
builder.Services.AddDbContext<TarefasDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection")));

//builder.Services.AddEntityFrameworkNpgsql()



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    //teste frontend
    //app.UseWebAssemblyDebugging();
    //
}
/*else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}*/

app.UseHttpsRedirection();
//teste frontend
//app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

//
//app.UseCors("myAllowSpecificOrigins");
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

//teste frontend
//app.MapRazorPages();
//
app.MapControllers();
//teste frontend
//app.MapFallbackToFile("index.html");
//

app.Run();