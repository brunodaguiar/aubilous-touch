using AubilousTouch.Core.Dto;
using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> SendMessage([FromBody] ChannelEmployeeMessage channelEmployeeMesssage)
        {
            await _service.SendMessageAsync(channelEmployeeMesssage);
            return Ok();
        }

        /// <summary>
        /// Obtem a lista de mensagens enviadas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SentMessagesDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetSentMessages()
        {
            return Ok(await _service.GetSentMessagesAsync());
        }
    }
}
