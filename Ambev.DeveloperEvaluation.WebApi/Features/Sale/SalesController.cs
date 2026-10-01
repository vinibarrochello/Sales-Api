using Ambev.DeveloperEvaluation.Application.Sale.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sale.GetSale;
using Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.CancelSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.UpdateSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SalesController(
        IMediator mediator,
        IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateSaleResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
        [FromBody] CreateSaleRequest request,
        CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateSaleCommand>(request);

            var result = await _mediator.Send(
            command,
            cancellationToken);

            var response = _mapper.Map<CreateSaleResponse>(result);

            return CreatedAtAction(
            nameof(GetById),
            new { id = response.Id },
            response);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(GetSaleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
        Guid id,
        CancellationToken cancellationToken)
        {
            var request = new GetSaleRequest
            {
                Id = id
            };

            var command = _mapper.Map<GetSaleCommand>(request);

            var result = await _mediator.Send(
            command,
            cancellationToken);

            var response = _mapper.Map<GetSaleResponse>(result);

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(UpdateSaleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(
        Guid id,
        [FromBody] UpdateSaleRequest request,
        CancellationToken cancellationToken)
        {
            request.Id = id;

            var command = _mapper.Map<UpdateSaleCommand>(request);

            var result = await _mediator.Send(
            command,
            cancellationToken);

            var response = _mapper.Map<UpdateSaleResponse>(result);

            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(CancelSale.CancelSaleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Cancel(
        Guid id,
        CancellationToken cancellationToken)
        {
            var request = new CancelSaleRequest
            {
                Id = id
            };

            var command = _mapper.Map<CancelSaleCommand>(request);

            var result = await _mediator.Send(
            command,
            cancellationToken);

            var response = _mapper.Map<CancelSale.CancelSaleResponse> (result);

            return Ok(response);
        }
    }
}
