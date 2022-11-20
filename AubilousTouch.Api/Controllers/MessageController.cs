using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AubilousTouch.Api.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _service;

        public MessageController(IMessageService service)
        {
            this._service = service;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] ChannelEmployeeMessage channelEmployeeMesssage)
        {
            await _service.SendMessageAsync(channelEmployeeMesssage);
            return Ok();
        }
    }
}
