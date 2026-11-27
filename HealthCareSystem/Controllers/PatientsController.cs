using HealthCareSystem.api.Filters;
using HealthCareSystem.BLL.DTOs;
using HealthCareSystem.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareSystem.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ActionExecutionLoggingFilter))]
    [ServiceFilter(typeof(ActionTimingFilter))]
    [ServiceFilter(typeof(ExceptionHandlingFilter))]
    [Authorize]
    public class PatientsController(IPatientService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await service.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await service.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientRequest request)
        {
            var result = await service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Value!.Id }, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePatientRequest request)
        {
            var result = await service.UpdateAsync(request);
            return result.IsSuccess ? NoContent() : NotFound(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.DeleteAsync(id);
            return result.IsSuccess ? NoContent() : NotFound(result);
        }
    }
}