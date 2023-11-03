using API.Data;
using API.Infrastructure;
using API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
var connectionString = builder.Configuration.GetConnectionString("ProductionDb");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Mapping
builder.Services.AddAutoMapper(typeof(GenericMapperProfile));

// Repositories
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<ITopicRepository, TopicRepository>();

// Swagger Configuration
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
        "v1",
        new OpenApiInfo { Title = "CW API - v1", Version = "v1"}
    );
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "API.xml");
    c.IncludeXmlComments( filePath );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
