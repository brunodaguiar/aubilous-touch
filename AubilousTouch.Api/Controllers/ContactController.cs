using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace AubilousTouch.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService service;

        public ContactController(IContactService service)
        {
            this.service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Contact>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult ReadFromFile(IFormFile file)
        {            
            if (file == null || file.Length == 0) return BadRequest();

            IList<Contact> contacts;
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);

                contacts = service.ReadFromFile(memoryStream.ToArray());
            }                
            
            return Ok(contacts);
        }
    }
}
