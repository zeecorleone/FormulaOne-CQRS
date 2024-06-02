
using FormulaOne.Application.Dtos.Driver.Responses;
using MediatR;

namespace FormulaOne.Application.Queries;

public class GetDriverQuery : IRequest<GetDriverResponse>
{
    public Guid DriverId { get; }

    public GetDriverQuery(Guid driverId)
    {
        DriverId = driverId;
    }
}
