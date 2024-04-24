using Cepedi.RabbitMQ.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.RabbitMQ.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PixController : Controller
{
    private readonly IMessageProducer _messageProducer;

    public PixController(IMessageProducer messageProducer)
    {
        _messageProducer = messageProducer;
    }

    [HttpGet]
    public IActionResult Get()
    {
        Pix pix = new Pix
        {
            Id = 1,
            Value = 1000,
            Description = "Pix payment"
        };
        _messageProducer.SendMessage(pix);
        return Ok(pix);
    }
}

internal class Pix
{
    public int Id { get; set; }
    public decimal Value { get; set; }
    public string Description { get; set; }
}