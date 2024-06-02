

using AutoMapper;
using FormulaOne.Application.Dtos.Driver.Responses;
using FormulaOne.Application.Queries;
using FormulaOne.Domain.Interfaces;
using MediatR;

namespace FormulaOne.Application.Handlers;

public class GetAllDriversHandler : IRequestHandler<GetAllDriversQuery, IEnumerable<GetDriverResponse>>
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;
    public GetAllDriversHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IEnumerable<GetDriverResponse>> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
    {
        var drivers = await _unitOfWork.Drivers.All();
        return _mapper.Map<IEnumerable<GetDriverResponse>>(drivers);
    }
}
