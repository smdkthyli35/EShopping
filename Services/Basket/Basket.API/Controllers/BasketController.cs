using Basket.Application.Features.Commands.Baskets.CreateShoppingCart;
using Basket.Application.Features.Commands.Baskets.DeleteBasketByUserName;
using Basket.Application.Features.Queries.Baskets.GetBasketByUserName;
using Basket.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{
    public class BasketController : ApiController
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("[action]/{userName}", Name = "GetBasketByUserName")]
        [ProducesResponseType(typeof(ShoppingCartResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartResponse>> GetBasketByUserName(string userName)
        {
            var query = new GetBasketByUserNameQuery(userName);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("CreateBasket")]
        [ProducesResponseType(typeof(ShoppingCartResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartResponse>> UpdateBasket([FromBody] CreateShoppingCartCommand createShoppingCartCommand)
        {
            var result = await _mediator.Send(createShoppingCartCommand);
            return Ok(result);
        }

        [HttpDelete]
        [Route("[action]/{userName}", Name = "DeleteBasketByUserName")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartResponse>> DeleteBasketByUserName(string userName)
        {
            var query = new DeleteBasketByUserNameCommand(userName);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
