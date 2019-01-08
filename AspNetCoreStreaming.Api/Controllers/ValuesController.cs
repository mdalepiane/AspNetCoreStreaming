using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetCoreStreaming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ILogger _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<int>> Get()
        {
            return Ok(GetIntValues());
        }

        private IEnumerable<int> GetIntValues()
        {
            foreach(var i in Enumerable.Range(0, 10))
            {
                foreach(var j in Enumerable.Range(0, 10000))
                {
                   yield return j;
                }

                _logger.LogInformation($"Finished group {i}");
                yield return -1;
                Task.Delay(1000).Wait();
            }
        }
    }
}
