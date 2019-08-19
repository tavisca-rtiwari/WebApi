using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloHiiController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Something went wrong";
        }
        [HttpGet("{input}")]
        public string Get(string input)
        {
            if (input.Equals("Hii"))
            {
                return "Hello";
            }
            else if (input.Equals("Hello"))
            {
                return "Hii";
            }
            return "Something went wrong";
        }
    }
}