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
        readonly IEmployeeService service;

        public ContactController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Produces(typeof(IList<Employee>))]
        public IActionResult ReadFromFile(byte[] file)
        {
            var contacts = service.ReadFromFile(file);
            
            return Ok(contacts);
        }
    }
}
