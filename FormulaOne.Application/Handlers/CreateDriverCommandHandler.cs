
using AutoMapper;
using FormulaOne.Application.Commands;
using FormulaOne.Application.Dtos.Driver.Responses;
using FormulaOne.Domain.Entities;
using FormulaOne.Domain.Interfaces;
using MediatR;

namespace FormulaOne.Application.Handlers;

public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, GetDriverResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public CreateDriverCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<GetDriverResponse> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<Driver>(request.DriverRequest);

        await _unitOfWork.Drivers.Add(result);
        await _unitOfWork.CompleteAsync();

        var driverResult = _mapper.Map<GetDriverResponse>(result);
        return driverResult;
    }
}
