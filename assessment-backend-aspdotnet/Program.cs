using assessment_backend_aspdotnet;
using assessment_backend_aspdotnet.CustomConfig;
using assessment_backend_aspdotnet.DataAccess.Context;
using assessment_backend_aspdotnet.DataAccess.Repositories.ClassRepository;
using assessment_backend_aspdotnet.DataAccess.Repositories.StudentRepository;
using assessment_backend_aspdotnet.DataAccess.Repositories.SubjectRepository;
using assessment_backend_aspdotnet.Interfaces.Manager;
using assessment_backend_aspdotnet.Interfaces.ManagerInterfaces;
using assessment_backend_aspdotnet.Interfaces.Repository;
using assessment_backend_aspdotnet.Managers.ClassManager;
using assessment_backend_aspdotnet.Managers.StudentManager;
using assessment_backend_aspdotnet.Managers.SubjectManager;
using assessment_backend_aspdotnet.Middlewares;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Automapper
IMapper mapper = MappingConfig.RegisterMappings().CreateMapper();
builder.Services.AddSingleton(mapper);

// Add services to the container.
builder.Services.AddDbContext<AssessmentContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DBConnection")));

//Add Repositories
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();

//Add Managers
builder.Services.AddScoped<IStudentManager, StudentManager>();
builder.Services.AddScoped<IClassManager, ClassManager>();
builder.Services.AddScoped<ISubjectManager, SubjectManager>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks().AddCheck<HealthCheck>("health_check");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//CORS
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapHealthChecks("/api/v3/healthCheck");

//Error handling
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
