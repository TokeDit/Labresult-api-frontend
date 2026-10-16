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
    options.AddPolicy("AllowFrontend", policy =>
            {
                policy.AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("http://localhost:5173");
            });

});


builder.Services.AddSingleton<ISampleRepository, SampleRepository>();

var app = builder.Build();
app.UseCors("AllowFrontend");


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

