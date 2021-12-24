using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Redbox.Core.Entities;
using Redbox.Infrastructure.Mediator.CommandHandlers;
using Redbox.Infrastructure.Mediator.CommandRequest;
using Redbox.Infrastructure.Mediator.CommandRequests;
using Redbox.Infrastructure.Mediator.Queries;
using Redbox.ViewModels;
using System;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Cart cart = await _mediator.Send(new GetCartByIdQuery() { Id = id });
            return Ok(_mapper.Map<CartVM>(cart));
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            int id = await _mediator.Send(new CreateCartCommandModel());
            return Ok(id);
        }

        [HttpPost("{cartId}/items")]
        public async Task<IActionResult> AddCartItem(int cartId, CartItemVM cartItemVM)
        {
            CartItem cartItem = await _mediator.Send(new AddCartItemCommandModel() { CartId = cartId, ItemId = cartItemVM.ItemId });
            return Ok(_mapper.Map<CartItemVM>(cartItem));
        }
        
        [HttpDelete("{cartId}/items")]
        public async Task<IActionResult> RemoveCartItem(int cartId, CartItemVM cartItemVM)
        {
            CartItem cartItem = await _mediator.Send(new RemoveCartItemCommandModel() { CartId = cartId, ItemId = cartItemVM.ItemId });
            return Ok(_mapper.Map<CartItemVM>(cartItem));
        }
        
       
        [HttpGet("{cartId}/price")]
        public async Task<IActionResult> GetCartInfoPrice(int cartId, string code)
        {
            double cartPrice = await _mediator.Send(new GetCartPriceQuery() { CartId = cartId, DiscountCode = code });
            return Ok(cartPrice);
        }

    }
}
