using LaboratorieAPI.Interfaces;
using LaboratorieAPI.Models;
using LaboratorieAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCors(options => 
{
    options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
            });

});


builder.Services.AddSingleton<ISampleRepository, SampleRepository>();

var app = builder.Build();
app.UseCors("AllowAll");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapSwagger();
app.MapControllers();



app.Run();

