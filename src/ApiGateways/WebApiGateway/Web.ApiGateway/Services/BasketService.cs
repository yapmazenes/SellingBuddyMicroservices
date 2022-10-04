using System.Net.Http;
using System.Threading.Tasks;
using Web.ApiGateway.Extensions;
using Web.ApiGateway.Models.Basket;
using Web.ApiGateway.Services.Interfaces;

namespace Web.ApiGateway.Services
{
    public class BasketService : IBasketService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<BasketData> GetById(string id)
        {
            var client = _httpClientFactory.CreateClient("basket");
            var response = await client.GetResponseAsync<BasketData>(id);

            return response ?? new BasketData(id);
        }

        public async Task<BasketData> UpdateAsync(BasketData currentBasket)
        {
            var client = _httpClientFactory.CreateClient("basket");
            var response = await client.PostGetResponseAsync<BasketData, BasketData>("update", currentBasket);

            return response;
        }
    }
}
