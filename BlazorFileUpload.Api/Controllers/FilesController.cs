using Microsoft.AspNetCore.Mvc;

namespace BlazorFileUpload.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilesController : ControllerBase
    {
        [HttpPost]
        public void Upload([FromForm] IEnumerable<IFormFile> files)
        {
            var count = files.Count();
            //Do something with files
        }

        [HttpGet]
        public string Hello()
        {
            return "Hello World!";
        }
    }
}