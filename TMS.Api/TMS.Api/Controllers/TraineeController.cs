﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TMS.Api.Responses;
using TMS.Domain.DTOs.shared;
using TMS.Domain.DTOs.Trainee;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence;

namespace TMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IResponseHandler _responseHandler;
        private readonly IMapper _mapper;

        public TraineeController(IUnitOfWork unitOfWork, IResponseHandler responseHandler, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _responseHandler = responseHandler;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrainees()
        {
            try
            {
                var trainees = await _unitOfWork.TraineeRepository.GetAllAsync();
                var traineeDtos = _mapper.Map<IEnumerable<TraineeResponseDto>>(trainees);
                return _responseHandler.Success(traineeDtos, "Trainees retrieved successfully.");
            }
            catch (Exception ex)
            {
                return _responseHandler.BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTraineeById(string id)
        {
            try
            {
                var trainee = await _unitOfWork.TraineeRepository.GetByIdAsync(id);
                if (trainee is null)
                {
                    return _responseHandler.NotFound("Trainee not found.");
                }
                var traineeDto = _mapper.Map<TraineeResponseDto>(trainee);
                return _responseHandler.Success(traineeDto, $"Trainee with ID {id} retrieved successfully.");
            }
            catch (Exception ex)
            {
                return _responseHandler.BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainee(string id, [FromBody] UpdateTraineeDto updateUserDto)
        {
            if (!ModelState.IsValid)
            {
                return _responseHandler.BadRequest("Invalid input data.");
            }

            try
            {
                var existingTrainee = await _unitOfWork.TraineeRepository.GetByIdAsync(id);
                if (existingTrainee == null)
                {
                    return _responseHandler.NotFound($"Trainee with ID {id} not found.");
                }

                // تحديث خصائص المتدرب
                existingTrainee.Email = updateUserDto.Email;
                existingTrainee.FirstName = updateUserDto.FirstName;
                existingTrainee.LastName = updateUserDto.LastName;

                if (!string.IsNullOrEmpty(updateUserDto.TrainerId))
                {
                    var trainer = await _unitOfWork.TrainerRepository.GetByIdAsync(updateUserDto.TrainerId);
                    if (trainer == null)
                    {
                        return _responseHandler.NotFound($"Trainer with ID {updateUserDto.TrainerId} not found.");
                    }

                    existingTrainee.TrainerId = updateUserDto.TrainerId;
                }

                await _unitOfWork.CommitAsync();

                var traineeDto = _mapper.Map<TraineeResponseDto>(existingTrainee);
                return _responseHandler.Success(traineeDto, $"Trainee with ID {id} updated successfully.");
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
        public async Task<IActionResult> DeleteTrainee(string id)
        {
            try
            {
                await _unitOfWork.TraineeRepository.DeleteAsync(id);
                await _unitOfWork.CommitAsync();
                return NoContent();
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
}
