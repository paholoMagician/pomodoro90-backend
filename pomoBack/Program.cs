
using Microsoft.EntityFrameworkCore;
using pomoBack.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerGen(c => {
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
    c.CustomSchemaIds(type => type.FullName);
});


var configuration = new ConfigurationBuilder().SetBasePath(builder.Environment.ContentRootPath).AddJsonFile("appsettings.json").Build();
var connectionString = configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<pomodoro90Context>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews().AddNewtonsoftJson(
    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
IServiceCollection serviceCollection = builder.Services.AddDbContext<pomodoro90Context>(opt => opt.UseInMemoryDatabase(databaseName: "pomodoro90"));

builder.Services.AddSignalR(options => 
{
    options.EnableDetailedErrors = true;
    options.MaximumReceiveMessageSize = 1024;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.WithOrigins("http://localhost:3652", "*")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod()
                                            .AllowCredentials()
                                           );

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllers();
app.UseAuthorization();


app.Run();
