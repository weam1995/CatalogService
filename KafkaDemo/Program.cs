using KafkaClient.Consumer;
using KafkaClient.Producer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();


await app.RunAsync();
