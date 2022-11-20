using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AubilousTouch.Api.Controllers
{
    [ApiController]
    [Route("api/contact")]
    public class ContactController : ControllerBase
    {
        readonly IEmployeeService _employeeService;
        readonly IMessageService _messageService;

        public ContactController(IEmployeeService employeeService, IMessageService messageService)
        {
            this._employeeService = employeeService;
            this._messageService = messageService;
        }

        /// <summary>
        /// Converte um arquivo em uma lista de Empregados
        /// </summary>
        /// <param name="file">Conteudo de um input='file'</param>
        /// <returns></returns>
        [HttpPost("ReadFromFile-DEPRECATED")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Employee>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult ReadFromFile(IFormFile file)
        {            
            if (file == null || file.Length == 0) return BadRequest();

            IList<Employee> contacts;
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);

                contacts = _employeeService.ReadFromFile(memoryStream.ToArray());
            }                
            
            return Ok(contacts);
        }
        
        /// <summary>
        /// Processa menssagem e contatos
        /// </summary>
        /// <param name="title">Assunto/Subject da mensagem</param>
        /// <param name="text">Text/Body da mensagem</param>
        /// <param name="file">Arquivo em Base64</param>
        /// <returns></returns>
        [HttpPost("send-communication")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Employee>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> SendCommunication(string title, string text, string file)
        {
            if(string.IsNullOrEmpty(title) || string.IsNullOrEmpty(text) || file == null || file.Length == 0)
                return BadRequest();

            Message message = await _messageService.SaveMessageAsync(title, text);

            try
            {

                await _employeeService.ReadFromBase64FileAsync(file, message.Id);
            } 
            catch (Exception e)
            {
                throw e;
            }

            return Ok();
        }
    }
}
