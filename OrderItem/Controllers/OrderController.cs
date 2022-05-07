using Microsoft.AspNetCore.Mvc;
using OrderItem.Models;
using OrderItem.DTO;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderItem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        IHttpClientFactory _httpClientFactory;
        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<Cart?> Post([FromBody]int menuItemId)
        {
            var httpClient = _httpClientFactory.CreateClient("OrderItem");
            httpClient.DefaultRequestHeaders.Add("Authorization", HttpContext.Request.Headers["Authorization"].ToString());

            var menuItem = await httpClient.GetFromJsonAsync<MenuItem>($"/api/MenuItem/{menuItemId}");
            if (menuItem == null)
                return null;

            var cart = new Cart
            {
                Id = 1,
                UserId = 1,
                MenuItemId = menuItemId,
                MenuItemName = menuItem.Name
            };
            return cart;
        }

    }
}
