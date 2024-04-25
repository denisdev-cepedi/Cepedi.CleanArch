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

    [HttpPost]
    public IActionResult Post([FromQuery] int id, [FromQuery] decimal value, [FromQuery] string description)
    {
        Pix pix = new Pix
        {
            Id = id,
            Value = value,
            Description = description
        };
        _messageProducer.SendMessage(pix);
        return Ok(pix);
    }
}

public class Pix
{
    public int Id { get; set; }
    public decimal Value { get; set; }
    public string Description { get; set; }
}