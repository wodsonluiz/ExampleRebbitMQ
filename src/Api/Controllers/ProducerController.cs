using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Producer.Abstractions;
using Producer.Model;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducerController : ControllerBase
    {
        private readonly ILogger<ProducerController> _logger;
        private readonly IProducerMessage _producerMessage;

        public ProducerController(ILogger<ProducerController> logger, IProducerMessage producerMessage)
        {
            _logger = logger;
            _producerMessage = producerMessage;
        }

        [HttpPost]
        public IActionResult Post([FromBody] MessageBindModel model)
        {
            _logger.LogInformation(@"Estou produzindo a mensagem {0}", model.Message);
            _producerMessage.Send(model.Message);
            return Ok();
        }
    }
}
