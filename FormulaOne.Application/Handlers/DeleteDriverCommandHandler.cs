
using AutoMapper;
using FormulaOne.Application.Commands;
using FormulaOne.Domain.Entities;
using FormulaOne.Domain.Interfaces;
using MediatR;

namespace FormulaOne.Application.Handlers;

public class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand, bool>
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;
    public DeleteDriverCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
    {
        var driver = await _unitOfWork.Drivers.GetById(request.DriverId);
        if(driver is null)
            return false;

        await _unitOfWork.Drivers.Delete(request.DriverId);
        await _unitOfWork.CompleteAsync();

        return true;

    }
}
