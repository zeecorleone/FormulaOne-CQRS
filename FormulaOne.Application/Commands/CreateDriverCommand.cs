
using FormulaOne.Application.Dtos.Driver.Requests;
using FormulaOne.Application.Dtos.Driver.Responses;
using MediatR;

namespace FormulaOne.Application.Commands;

public class CreateDriverCommand : IRequest<GetDriverResponse>
{
    public CreateDriverRequest DriverRequest { get; }
    public CreateDriverCommand(CreateDriverRequest driverRequest)
    {
        DriverRequest = driverRequest;
    }
}
