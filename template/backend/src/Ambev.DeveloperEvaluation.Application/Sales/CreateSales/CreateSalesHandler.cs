using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSales;

public class CreateSalesHandler :IRequestHandler<CreateSalesCommand, CreateSalesResult>
{
    private readonly ISalesRecordsRepository _salesRepository;
    private readonly IMapper _mapper;
    public CreateSalesHandler(ISalesRecordsRepository salesRepository, IMapper mapper)
    {
        _salesRepository = salesRepository;
        _mapper = mapper;
    }
    public async Task<CreateSalesResult> Handle(CreateSalesCommand request, CancellationToken cancellationToken)
    {

        var salesRecord =  _mapper.Map<SalesRecords>(request);
        var createdSalesRecord = await _salesRepository.CreateAsync(salesRecord, cancellationToken);
        var result =   _mapper.Map<CreateSalesResult>(createdSalesRecord);
        return result;


    }
}
