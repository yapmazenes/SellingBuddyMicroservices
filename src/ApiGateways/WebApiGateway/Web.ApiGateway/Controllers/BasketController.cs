using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ApiGateway.Models.Basket;

namespace Web.ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        [HttpPost]
        [Route("items")]
        public async Task<ActionResult> AddBasketItemAsync([FromBody] AddBasketItemRequest request)
        {

        }
    }
}
