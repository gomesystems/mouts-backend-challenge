using Ambev.DeveloperEvaluation.Application.Sales.CreateSales;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSales;
using Ambev.DeveloperEvaluation.Application.Sales.GetSales;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesRecord.CreateSales;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesRecord.DeleteSales;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesRecord.GetSales;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesRecord
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesRecordsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public SalesRecordsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }



        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateSalesResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSalesRecord([FromBody] CreateSalesRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateSalesRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            var command = _mapper.Map<CreateSalesCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);
            return Created(string.Empty, new ApiResponseWithData<CreateSalesResponse>
            {
                Success = true,
                Message = "Sales-record created successfully",
                Data = _mapper.Map<CreateSalesResponse>(response)
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSalesRecord([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteSalesRequest { Id = id };
            var validator = new DeleteSalesRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            var command = _mapper.Map<DeleteSalesCommand>(request.Id);
            var result = await _mediator.Send(command, cancellationToken);
            if (!result.Success)
            {
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Sales record not found"
                });
            }
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Sales record deleted successfully"
            });
        }



        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetSalesRecordsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSalesRecord([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new GetSalesRecordsRequest { Id = id };
            var validator = new GetSalesRecordsRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetSalesRecordsCommand>(request.Id);
            var response = await _mediator.Send(command, cancellationToken);


            if (response == null)
            {
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Sales record not found"
                });
            }
            return Ok(new ApiResponseWithData<GetSalesRecordsResponse>
            {
                Success = true,
                Message = "Sales record retrieved successfully",
                Data = _mapper.Map<GetSalesRecordsResponse>(response)
            });
        }

    }
}
