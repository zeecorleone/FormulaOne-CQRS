using AutoMapper;
using FormulaOne.Application.Commands;
using FormulaOne.Application.Dtos.Driver.Requests;
using FormulaOne.Domain.Entities;
using FormulaOne.Domain.Interfaces;
using MediatR;

namespace FormulaOne.Application.Handlers;

public class UpdateDriverCommandHandler : IRequestHandler<UpdateDriverCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public UpdateDriverCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<Driver>(request.DriverRequest);
        var updated = await _unitOfWork.Drivers.Update(result);
        if (!updated)
            return false;
        await _unitOfWork.CompleteAsync();

        return true;

    }
}
