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
        private readonly IContactService service;

        public ContactController(IContactService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Produces(typeof(IList<Contact>))]
        public IActionResult ReadFromFile(byte[] file)
        {
            var contacts = service.ReadFromFile(file);
            
            return Ok(contacts);
        }
    }
}
