using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web.ApiGateway.Models.Basket;
using Web.ApiGateway.Services.Interfaces;

namespace Web.ApiGateway.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize()]
    public class BasketController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;

        public BasketController(ICatalogService catalogService, IBasketService basketService)
        {
            _catalogService = catalogService;
            _basketService = basketService;
        }

        [HttpPost]
        [Route("items")]
        public async Task<ActionResult> AddBasketItemAsync([FromBody] AddBasketItemRequest request)
        {
            if (request is null || request.Quantity == 0)
            {
                return BadRequest("Invalid Payload");
            }

            var item = await _catalogService.GetCatalogItemAsync(request.CatalogItemId);

            var currentBasket = await _basketService.GetById(request.BasketId);

            var product = currentBasket.Items.SingleOrDefault(i => i.ProductId == item.Id);

            if (product != null)
            {
                product.Quantity += request.Quantity;
            }
            else
            {
                currentBasket.Items.Add(new BasketDataItem
                {
                    UnitPrice = item.Price,
                    PictureUrl = item.PictureUrl,
                    ProductId = item.Id,
                    ProductName = item.Name,
                    Quantity = request.Quantity,
                    Id = Guid.NewGuid().ToString()
                });
            }

            await _basketService.UpdateAsync(currentBasket);

            return Ok();
        }
    }
}
