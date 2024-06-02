

using AutoMapper;
using FormulaOne.Application.Dtos.Driver.Responses;
using FormulaOne.Application.Queries;
using FormulaOne.Domain.Interfaces;
using MediatR;

namespace FormulaOne.Application.Handlers;

public class GetDriverHandler : IRequestHandler<GetDriverQuery, GetDriverResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public GetDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<GetDriverResponse> Handle(GetDriverQuery request, CancellationToken cancellationToken)
    {
        var driver = await _unitOfWork.Drivers.GetById(request.DriverId);
        
        return driver is null ? null : _mapper.Map<GetDriverResponse>(driver);
    }
}
