using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AubilousTouch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _service;

        public MessageController(IMessageService service)
        {
            this._service = service;
        }

        [HttpPost]
        public void SendMessage([FromBody] Message message)
        {
            _service.SendMessage(message);
        }
    }
}
