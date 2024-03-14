using Microsoft.AspNetCore.Mvc;

namespace url_encoder.Url
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UrlController : ControllerBase
    {

        private readonly IUrlService _urlService;

        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpPost]
        public async Task<string> Add([FromBody] string url) { 
            var urlEncode = await _urlService.Add(url);
            return urlEncode;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> FindByCode([FromRoute] string code)
        {
             var result = await _urlService.FindByCode(code);

            if (result.succes)
            {
               return Redirect(result.url);
            }

            return BadRequest("Url não encontrada!");

        }
    }
}
