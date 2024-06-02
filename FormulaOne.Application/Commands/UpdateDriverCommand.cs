
using FormulaOne.Application.Dtos.Driver.Requests;
using MediatR;

namespace FormulaOne.Application.Commands;

public class UpdateDriverCommand : IRequest<bool>
{
    public UpdateDriverRequest DriverRequest { get; }

    public UpdateDriverCommand(UpdateDriverRequest driverRequest)
    {
        DriverRequest = driverRequest;
    }
}
