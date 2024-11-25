using CleanArchDemo1.Application;
using CleanArchDemo1.Application.UseCases.Student.CreateStudents;
using CleanArchDemo1.Application.UseCases.Student.DeleteStudent;
using CleanArchDemo1.Application.UseCases.Student.GetStudentById;
using CleanArchDemo1.Application.UseCases.Student.GetStudents;
using CleanArchDemo1.Application.UseCases.Student.UpdateStudent;
using CleanArchDemo1.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<CreateStudentsHandler>();
builder.Services.AddScoped<DeleteStudentHandler>();
builder.Services.AddScoped<UpdateStudentHandler>();
builder.Services.AddScoped<GetStudentsHandler>();
builder.Services.AddScoped<GetStudentByIdHandler>();

string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shruti.khandare\Documents\CleanArchDemo1.mdf;Integrated Security=True;Connect Timeout=30";
builder.Services.AddDbContext<StudentsDbContext>(options => options.UseSqlServer(connectionString));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
