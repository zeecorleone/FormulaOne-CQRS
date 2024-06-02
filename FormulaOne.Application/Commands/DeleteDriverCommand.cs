
using MediatR;

namespace FormulaOne.Application.Commands;

public class DeleteDriverCommand : IRequest<bool>
{
    public Guid DriverId { get; }
    public DeleteDriverCommand(Guid driverId)
    {
        DriverId = driverId;
    }


}
