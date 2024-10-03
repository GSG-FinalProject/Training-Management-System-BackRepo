using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS.Api.Responses;
using TMS.Domain.DTOs.Trainer;
using TMS.Domain.Entities;
using TMS.Domain.Interfaces.Persistence.Repositories;

namespace TMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IResponseHandler _responseHandler;
        private readonly IMapper _mapper;

        public TrainerController(ITrainerRepository trainerRepository, IResponseHandler responseHandler, IMapper mapper)
        {
            _trainerRepository = trainerRepository;
            _responseHandler = responseHandler;
            _mapper = mapper;
        }

        // GET: api/Trainer
        [HttpGet]
        public async Task<IActionResult> GetAllTrainers()
        {
            try
            {
                var trainers = await _trainerRepository.GetAllAsync();
                var trainerDtos = _mapper.Map<IEnumerable<TrainerResponseDto>>(trainers);
                return _responseHandler.Success(trainerDtos, "Trainers retrieved successfully.");
            }
            catch (Exception ex)
            {
                return _responseHandler.BadRequest(ex.Message);
            }
        }

        // GET: api/Trainer/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainerById(string id)
        {
            try
            {
                var trainer = await _trainerRepository.GetByIdAsync(id);
                var trainerDto = _mapper.Map<TrainerResponseDto>(trainer); // تحويل الكيان إلى DTO
                return _responseHandler.Success(trainerDto, $"Trainer with ID {id} retrieved successfully.");
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

        // PUT: api/Trainer/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainer(string id, [FromBody] Trainer trainer)
        {
            try
            {
                var updatedTrainer = await _trainerRepository.UpdateAsync(id, trainer);
                var trainerDto = _mapper.Map<TrainerResponseDto>(updatedTrainer); // تحويل الكيان المحدث إلى DTO
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

        // DELETE: api/Trainer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainer(string id)
        {
            try
            {
                var result = await _trainerRepository.DeleteAsync(id);
                return _responseHandler.Success(result);
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
