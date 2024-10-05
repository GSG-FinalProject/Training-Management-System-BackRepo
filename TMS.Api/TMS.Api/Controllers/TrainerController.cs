﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMS.Api.Responses;
using TMS.Domain.DTOs.Trainer;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence;

namespace TMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrainerController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IResponseHandler _responseHandler;
    private readonly IMapper _mapper;

    public TrainerController(IUnitOfWork unitOfWork, IResponseHandler responseHandler, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _responseHandler = responseHandler;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTrainers()
    {
        try
        {
            var trainers = await _unitOfWork.TrainerRepository.GetAllAsync();
            var trainerDtos = _mapper.Map<IEnumerable<TrainerResponseDto>>(trainers);
            return _responseHandler.Success(trainerDtos, "Trainers retrieved successfully.");
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTrainerById(string id)
    {
        try
        {
            var trainer = await _unitOfWork.TrainerRepository.GetByIdAsync(id);
            if (trainer is null)
            {
                return _responseHandler.NotFound("Trainer not found.");
            }
            var trainerDto = _mapper.Map<TrainerResponseDto>(trainer);
            return _responseHandler.Success(trainerDto, $"Trainer with ID {id} retrieved successfully.");
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTrainer(string id, [FromBody] Trainer trainer)
    {
        if (!ModelState.IsValid)
        {
            return _responseHandler.BadRequest("Invalid input data.");
        }

        try
        {
            var updatedTrainer = await _unitOfWork.TrainerRepository.UpdateAsync(id, trainer);
            var trainerDto = _mapper.Map<TrainerResponseDto>(updatedTrainer);
            await _unitOfWork.CommitAsync();
            return _responseHandler.Success(trainerDto, $"Trainer with ID {id} updated successfully.");
        }
        catch (KeyNotFoundException ex)
        {
            return _responseHandler.NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrainer(string id)
    {
        try
        {
            await _unitOfWork.TrainerRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
            return _responseHandler.Success("Trainer deleted successfully.");
        }
        catch (KeyNotFoundException ex)
        {
            return _responseHandler.NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest(ex.Message);
        }
    }
}