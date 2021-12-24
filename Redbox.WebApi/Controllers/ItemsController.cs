using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Redbox.Core.Entities;
using Redbox.Infrastructure.Mediator.Queries;
using Redbox.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Redbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ItemsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Item> items = await _mediator.Send(new GetAllItemsQuery());
            IEnumerable<ItemVM> itemsVM = _mapper.Map<IEnumerable<Item>, IEnumerable<ItemVM>>(items);
            return Ok(itemsVM);
        }
    }
}
