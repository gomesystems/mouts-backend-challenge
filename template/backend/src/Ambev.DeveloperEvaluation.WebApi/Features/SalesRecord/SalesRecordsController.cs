using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesRecord.CreateSales;
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

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseWithData<SalesRecordsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllSalesRecords(CancellationToken cancellationToken)
        {
            ///parei aqui
            var query = new GetAllSalesRecordsQuery();

            var salesRecords = await _mediator.Send(query, cancellationToken);
            if (salesRecords == null || !salesRecords.Any())
            {
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "No sales records found"
                });
            }
            var response = _mapper.Map<List<SalesRecordsResponse>>(salesRecords);
            return Ok(new ApiResponseWithData<List<SalesRecordsResponse>>
            {
                Success = true,
                Message = "Sales records retrieved successfully",
                Data = response
            });
        }

    }
}
