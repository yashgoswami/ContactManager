using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        /// <summary>
        /// ILogger object
        /// </summary>
        protected ILogger<T> Logger { get; set; }

        /// <summary>
        /// Base Controller Constructor
        /// </summary>
        /// <param name="logger">ILogger</param>
        public BaseController(ILogger<T> logger)
        {
            Logger = logger;
        }
    }
}
