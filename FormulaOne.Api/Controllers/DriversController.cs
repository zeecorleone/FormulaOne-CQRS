using AutoMapper;
using FormulaOne.Application.Dtos.Driver.Requests;
using FormulaOne.Application.Dtos.Driver.Responses;
using FormulaOne.Domain.Entities;
using FormulaOne.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers;

public class DriversController : BaseController
{
    public DriversController(IUnitOfWork unitOfWork, IMapper mapper) 
        : base(unitOfWork, mapper)
    {
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(GetDriverResponse), StatusCodes.Status200OK)]
    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriver(Guid driverId)
    {
        var driver = await _unitOfWork.Drivers.GetById(driverId);

        if (driver is null)
            return NotFound();

        var result = _mapper.Map<GetDriverResponse>(driver);

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

        var result = _mapper.Map<Driver>(driver);

        await _unitOfWork.Drivers.Add(result);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetDriver), new { driverId = result.Id });
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPut("")]
    public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driver)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = _mapper.Map<Driver>(driver);

        await _unitOfWork.Drivers.Update(result);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }

    [ProducesResponseType(typeof(GetDriverResponse), StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<IActionResult> GetDriver()
    {
        var driver = await _unitOfWork.Drivers.All();

        var result = _mapper.Map<IEnumerable<GetDriverResponse>>(driver);

        return Ok(result);
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpDelete("{driverId:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid driverId)
    {
        var driver = await _unitOfWork.Drivers.GetById(driverId);

        if (driver is null)
            return NotFound();

        await _unitOfWork.Drivers.Delete(driverId);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }

}
