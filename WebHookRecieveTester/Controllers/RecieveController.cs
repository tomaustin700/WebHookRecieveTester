using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebHookRecieveTester.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecieveController : ControllerBase
    {
       
        private readonly ILogger<RecieveController> _logger;

        public RecieveController(ILogger<RecieveController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task Recieve()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = await reader.ReadToEndAsync();

                _logger.LogInformation(body);
            }
        }
    }
}
