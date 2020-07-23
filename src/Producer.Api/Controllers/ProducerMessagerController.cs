using Microsoft.AspNetCore.Mvc;
using Producer.Abstractions;
using Producer.Model;
using System.Threading.Tasks;

namespace Producer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProducerMessagerController : ControllerBase
    {
        private readonly IProducerMessage _producerMessage;

        public ProducerMessagerController(IProducerMessage producerMessage)
        {
            _producerMessage = producerMessage;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMassager([FromBody]MessageBindModel messageBindModel)
        {
            await _producerMessage.Send(messageBindModel.Message);

            return Created(messageBindModel.Message, true);
        }
    }
}
