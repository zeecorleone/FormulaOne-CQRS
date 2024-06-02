using AutoMapper;
using FormulaOne.Application.Commands;
using FormulaOne.Application.Dtos.Driver.Requests;
using FormulaOne.Application.Dtos.Driver.Responses;
using FormulaOne.Application.Queries;
using FormulaOne.Domain.Entities;
using FormulaOne.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class DriversController : BaseController
{
    

    public DriversController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
        : base(unitOfWork, mapper, mediator)
    {

    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(GetDriverResponse), StatusCodes.Status200OK)]
    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriver(Guid driverId)
    {
        var query = new GetDriverQuery(driverId);
        var result = await _mediator.Send(query);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost("")]
    public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var command = new CreateDriverCommand(driver);
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetDriver), new { driverId = result.DriverId });
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPut("")]
    public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driver)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var command = new UpdateDriverCommand(driver);
        var result = await _mediator.Send(command);

        return result ? NoContent() : BadRequest();
    }

    [ProducesResponseType(typeof(GetDriverResponse), StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<IActionResult> GetDriver()
    {
        var query = new GetAllDriversQuery();
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpDelete("{driverId:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid driverId)
    {
        var command = new DeleteDriverCommand(driverId);
        var result = await _mediator.Send(command);

        return result ? NoContent() : BadRequest();
    }

}
