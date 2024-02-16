using ClickUp.Repositories;
using ClickUp.Repositories.DbContext;
using ClickUp.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure the HTTP request pipeline.
builder.Services.Configure<MongoSetting>(builder.Configuration.GetSection(nameof(MongoSetting)));

builder.Services.AddSingleton<IMongoSetting>
    (d => d.GetRequiredService<IOptions<MongoSetting>>().Value);

builder.Services.AddSingleton<MongoDbContext>();



// Repositories 
#region
builder.Services.AddScoped<FolderRepository>();
builder.Services.AddScoped<SpaceRepository>();
builder.Services.AddScoped<ListRepository>();
builder.Services.AddScoped<TaskRepository>();

#endregion

//Services
builder.Services.AddScoped<FolderService>();
builder.Services.AddScoped<SpacesService>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<ListService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
