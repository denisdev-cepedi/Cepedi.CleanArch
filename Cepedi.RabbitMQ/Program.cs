using Cepedi.RabbitMQ;
using Cepedi.RabbitMQ.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IMessageProducer, ProducerRabbitMQ>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();
