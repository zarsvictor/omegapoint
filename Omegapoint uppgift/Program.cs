using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Omegapoint_uppgift.Models;

var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("PersonContext") ??
     throw new InvalidOperationException("Connection string 'PersonContext'" +
    " not found.");

// Add services to the container.


//Figure out proper cors handling
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("https://localhost")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<PersonContext>(opt =>
    opt.UseSqlServer(conString));

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();
//TODO: Add proper auth with users and/or JWT tokens
//builder.Services.AddAuthorization(options =>
//{
//    // By default, all incoming requests will be authorized according to the default policy.
//    options.FallbackPolicy = options.DefaultPolicy;
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors();

//app.UseAuthorization();


app.MapControllers();

app.Run();
