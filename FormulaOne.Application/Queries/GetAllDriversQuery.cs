
using FormulaOne.Application.Dtos.Driver.Responses;
using MediatR;

namespace FormulaOne.Application.Queries;

public class GetAllDriversQuery : IRequest<IEnumerable<GetDriverResponse>>
{
}
