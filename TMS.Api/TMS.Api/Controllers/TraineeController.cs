using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.Api.Responses;
using TMS.Domain.DTOs.Trainee;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence.Repositories;

namespace TMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeController : ControllerBase
    {
        private readonly ITraineeRepository _traineeRepository;
        private readonly IMapper _mapper;
        private readonly IResponseHandler _responseHandler;

        public TraineeController(ITraineeRepository traineeRepository, IMapper mapper, IResponseHandler responseHandler)
        {
            _traineeRepository = traineeRepository;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trainees = await _traineeRepository.GetAllAsync();
            var traineeDtos = _mapper.Map<IEnumerable<TraineeResponseDto>>(trainees);
            return _responseHandler.Success(traineeDtos, "Retrieved all trainees successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var trainee = await _traineeRepository.GetByIdAsync(id);
            if (trainee is null)
            {
                return _responseHandler.NotFound("Trainee not found");
            }
            var traineeDto = _mapper.Map<TraineeResponseDto>(trainee);
            return _responseHandler.Success(traineeDto, "Trainee retrieved successfully");
        }

        [HttpGet("by-training-hours/{hours}")]
        public async Task<IActionResult> GetByTrainingHours(int hours)
        {
            var trainees = await _traineeRepository.GetByTrainingHoursAsync(hours);
            var traineeDtos = _mapper.Map<IEnumerable<TraineeResponseDto>>(trainees);
            return _responseHandler.Success(traineeDtos, $"Trainees with {hours} training hours retrieved successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Trainee trainee)
        {
            var existingTrainee = await _traineeRepository.GetByIdAsync(id);
            if (existingTrainee is null)
            {
                return _responseHandler.NotFound("Trainee not found");
            }

            await _traineeRepository.UpdateAsync(id, trainee);
            return _responseHandler.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var trainee = await _traineeRepository.GetByIdAsync(id);
            if (trainee is null)
            {
                return _responseHandler.NotFound("Trainee not found");
            }

            await _traineeRepository.DeleteAsync(id);
            return _responseHandler.NoContent();
        }
    }
}
