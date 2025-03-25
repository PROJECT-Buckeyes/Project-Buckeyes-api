using Microsoft.AspNetCore.Mvc;
using Buckeyes.Domain.Catalog;

namespace Buckeyes.Api.Controllers {
    [ApiController]
    [Route("[controller]")]

    public class CatalogController: ControllerBase {
        [HttpGet]
        public IActionResult GetItems(){
            return Ok("Hello World!");
        }
    }
}