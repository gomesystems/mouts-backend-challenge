using Ambev.DeveloperEvaluation.Application.Sales.CreateSales;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class CreateSalesHandlerTests
{
    private readonly ISalesRecordsRepository _salesRepository;
    private readonly IMapper _mapper;
    private readonly CreateSalesHandler _handler;

   
    public CreateSalesHandlerTests()
    {
        _salesRepository = Substitute.For<ISalesRecordsRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new CreateSalesHandler(_salesRepository, _mapper);
    }

    [Fact(DisplayName = "Handle should create a new sales record successfully")]
    public async Task Handle_ShouldCreateNewSalesRecord()
    {
        // Arrange
        var command = new CreateSalesCommand
        {
            ProductName = "Product A",
            Quantity = 10,
            Price = 15.5m,
            SaleDate = DateTime.UtcNow
        };
        var salesRecord = new SalesRecords
        {
            Id = Guid.NewGuid(),
          //  ProductName = command.ProductName,
            Quantity = command.Quantity,
            UnitPrice = command.Price,
            SaleDate = command.SaleDate
        };
        var expectedResult = new CreateSalesResult
        {
            Id = salesRecord.Id,
          
        };
        _mapper.Map<SalesRecords>(command).Returns(salesRecord);
        _salesRepository.CreateAsync(Arg.Any<SalesRecords>(), Arg.Any<CancellationToken>())
                        .Returns(salesRecord);
        _mapper.Map<CreateSalesResult>(salesRecord).Returns(expectedResult);
        // Act
        var result = await _handler.Handle(command, CancellationToken.None);
        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(expectedResult.Id);
        result.Should().BeOfType<CreateSalesResult>();


        await _salesRepository.Received(1).CreateAsync(Arg.Any<SalesRecords>(), Arg.Any<CancellationToken>());
    }

}
