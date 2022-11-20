using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AubilousTouch.Api.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _service;

        public MessageController(IMessageService service)
        {
            this._service = service;
        }

        [HttpPost]
        public void SendMessage([FromBody] ChannelEmployeeMessage channelEmployeeMesssage)
        {
            _service.SendMessage(channelEmployeeMesssage);
        }
    }
}
