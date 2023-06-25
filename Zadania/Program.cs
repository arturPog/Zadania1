using AutoMapper;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using JavaScriptEngineSwitcher.V8;
using Microsoft.EntityFrameworkCore;
using React.AspNet;
using Zadania.Data;
using Zadania.MappingProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConection");
builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseSqlite(connectionString));


//// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile));



builder.Services.AddHttpClient();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//React add start
//Add IHttpContextAccessor for accessing Static Files.
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//Add React.
builder.Services.AddReact();

//Add JsEngineSwitcher V8.
builder.Services.AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName).AddV8();

//React add stop

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

////Dodaj plik ReactJS.
//app.UseReact(config =>
//{
//    config.AddScript("~/scripts/HelloWorld.jsx");
//});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
