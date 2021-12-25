using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redbox.Core.Entities;
using Redbox.Infrastructure.Mediator.CommandRequest;
using Redbox.Infrastructure.Mediator.CommandRequests;
using Redbox.Infrastructure.Mediator.Queries;
using Redbox.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Redbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CartsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Cart> carts = await _mediator.Send(new GetAllCartsQuery());
            IEnumerable<CartVM> cartsVM = _mapper.Map<IEnumerable<Cart>, IEnumerable<CartVM>>(carts);
            return Ok(cartsVM);
        }

        [HttpGet("{cartId}")]
        public async Task<IActionResult> GetById(int cartId)
        {
            Cart cart = await _mediator.Send(new GetCartByIdQuery() { Id = cartId });
            return Ok(_mapper.Map<CartVM>(cart));
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            int id = await _mediator.Send(new CreateCartCommandModel());
            return new ObjectResult(new CartVM() { Id = id }) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpGet("{cartId}/items")]
        public async Task<IActionResult> GetCartItems(int cartId)
        {
            ICollection<CartItem> cartItems = await _mediator.Send(new GetCartItemsQuery() { CartId = cartId });
            return Ok(_mapper.Map<ICollection<CartItemVM>>(cartItems));
        }

        [HttpPost("{cartId}/items/{itemId}")]
        public async Task<IActionResult> AddCartItem(int cartId, int itemId)
        {
            if (itemId < 0)
            {
                return BadRequest();
            }

            CartItem cartItem = await _mediator.Send(new AddCartItemCommandModel() { CartId = cartId, ItemId = itemId });
            CartItemVM cartItemVM = _mapper.Map<CartItemVM>(cartItem);
            return new ObjectResult(cartItemVM) { StatusCode = StatusCodes.Status202Accepted};
        }
        
        [HttpDelete("{cartId}/items/{itemId}")]
        public async Task<IActionResult> RemoveCartItem(int cartId, int itemId)
        {
            if (itemId < 0)
            {
                return BadRequest();
            }

            bool result = await _mediator.Send(new RemoveCartItemCommandModel() { CartId = cartId, ItemId = itemId });
            return Ok(result);
        }
        
       
        [HttpGet("{cartId}/price")]
        public async Task<IActionResult> GetPrice(int cartId, string code)
        {
            double cartPrice = await _mediator.Send(new GetCartPriceQuery() { CartId = cartId, DiscountCode = code });
            return Ok(cartPrice);
        }
    }
}
