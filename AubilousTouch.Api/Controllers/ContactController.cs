using AubilousTouch.Core.Interfaces.Services;
using AubilousTouch.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AubilousTouch.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        readonly IContactService service;

        public ContactController(IContactService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Produces(typeof(IEnumerable<Contact>))]
        public IActionResult ReadFromFile([FromBody] byte[] file)
        {            
            var contacts = service.ReadFromFile(file);
            
            return Ok(contacts);
        }
    }
}
