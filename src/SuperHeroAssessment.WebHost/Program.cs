using FluentValidation;
using FluentValidation.AspNetCore;
using MongoDB.Driver;
using SuperHeroAssessment.Api.Validation;
using SuperHeroAssessment.Application.Handlers;
using SuperHeroAssessment.Domain.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(BaseHandler).Assembly));
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssemblyContaining<BaseValidator>();

builder.Services.AddSingleton(typeof(MongoUrl), x => new MongoUrl(builder.Configuration["Mongo:ConnectionString"]));
builder.Services.AddSingleton(typeof(IMongoClient), x => new MongoClient(builder.Configuration["Mongo:ConnectionString"]));
builder.Services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));

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
