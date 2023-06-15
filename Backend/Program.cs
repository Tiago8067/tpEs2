global using BusinessLogic.Entities;
using Backend.Services.UtilizadorService;
using BusinessLogic.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//teste frontend
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
//builder.UseBlazorWebAssemblyAot();
//


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUtilizadorService, UtilizadorService>();

// Add default connection string for the Web API controllers
/*builder.Services.AddDbContext<ES2DbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection"))
);*/
builder.Services.AddDbContext<TarefasDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    //teste frontend
    app.UseWebAssemblyDebugging();
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
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
//

app.UseAuthorization();

//teste frontend
app.MapRazorPages();
//
app.MapControllers();
//teste frontend
app.MapFallbackToFile("index.html");
//

app.Run();