using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using UescColcicAPI.Middlewares;
using UescColcicAPI.Services;
using UescColcicAPI.Services.Auth;
using UescColcicAPI.Services.BD;
using UescColcicAPI.Services.BD.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureInfrastructure(builder.Configuration);
builder.Services.AddScoped<IProjectCRUD, ProjectCRUD>();
builder.Services.AddScoped<ISkillCRUD, SkillCRUD>();
builder.Services.AddScoped<IStudentCRUD, StudentCRUD>();
builder.Services.AddScoped<IBaseLog, RequestLogService>();
builder.Services.AddScoped<IUserCRUD, UserCRUD>();
builder.Services.AddScoped<ITokenGeneration, TokenGeneration>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ResponseAppendMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
