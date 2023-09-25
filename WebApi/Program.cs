using Infrastructure.Data;
using Infrastructure.Services;
using Infrastructure.Services.ClassroomServices;
using Infrastructure.Services.ExamServices;
using Infrastructure.Services.ResultServices;
using Infrastructure.Services.StudentServices;
using Infrastructure.Services.SubjectServices;
using Infrastructure.Services.TeacherServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(data=> data.UseNpgsql(connection));
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IResultService, ResulteService>();
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IClassroomService, ClassroomService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
