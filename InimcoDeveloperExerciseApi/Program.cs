
using Serilog;
using SocialSkillsApi.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register the Swagger generator, defining 1 or more Swagger documents
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();
builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));


// Add FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();


// Add Health Checks
builder.Services.AddHealthChecks();


builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Social Skills API v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

app.UseSerilogRequestLogging(); // Enable Serilog request logging

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");

app.Run();