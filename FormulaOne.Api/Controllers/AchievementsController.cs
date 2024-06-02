
using AutoMapper;
using FormulaOne.Application.Dtos.Driver.Requests;
using FormulaOne.Application.Dtos.Driver.Responses;
using FormulaOne.Domain.Entities;
using FormulaOne.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace FormulaOne.Api.Controllers;

public class AchievementsController : BaseController
{
    public AchievementsController(IUnitOfWork unitOfWork, IMapper mapper) 
        : base(unitOfWork, mapper)
    {
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(DriverAchievementResponse), StatusCodes.Status200OK)]
    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriverAchievements(Guid driverId)
    {
        var driverAchievements = await _unitOfWork.Achievements.GetDriverAchievementAsync(driverId);

        if(driverAchievements is null)
            return NotFound("Acheivements not found");

        var result = _mapper.Map<DriverAchievementResponse>(driverAchievements);
        
        return Ok(result);
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost("")]
    public async Task<IActionResult> AddAchievement([FromBody] CreateDriverAchievementRequest achievement)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var result = _mapper.Map<Achievement>(achievement);

        await _unitOfWork.Achievements.Add(result);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetDriverAchievements), new { driverId = result.DriverId }, null);
    }

    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPut("")]
    public async Task<IActionResult> UpdateAchievements([FromBody] UpdateDriverAchievementRequest achievement)
    {
        if(!ModelState.IsValid)
            return BadRequest();

        var result = _mapper.Map<Achievement>(achievement);
        
        await _unitOfWork.Achievements.Update(result);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }

}
