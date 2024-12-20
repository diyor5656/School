using FluentValidation;
using FluentValidation.AspNetCore;
using School.API;
using School.API.Filters;
using School.API.Middleware;
using School.Application;
using School.Application.Models.Validators;
using School.Application.Services;
using School.Application.Services.Impl;
using School.Application.Services.ServicesByS;
using School.DataAccess;
using School.DataAccess.Persistence;
using School.DataAccess.Repositories.Impl;
using School.DataAccess.Repositories;
using School.Application.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(
    config => config.Filters.Add(typeof(ValidateModelAttribute))
);

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(IValidationsMarker));
builder.Services.AddScoped<IAllService, CategoryService>();
builder.Services.AddSwagger();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<JwtHelper>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddDataAccess(builder.Configuration)
    .AddApplication(builder.Environment);

builder.Services.AddJwt(builder.Configuration);

builder.Services.AddEmailConfiguration(builder.Configuration);

var app = builder.Build();

using var scope = app.Services.CreateScope();

await AutomatedMigration.MigrateAsync(scope.ServiceProvider);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "LMS API V1");
        c.RoutePrefix = "swagger";
    });
}


app.UseHttpsRedirection();

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<PerformanceMiddleware>();

app.UseMiddleware<TransactionMiddleware>();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();

