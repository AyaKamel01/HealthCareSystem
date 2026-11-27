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
    public class AppointmentsController(IAppointmentService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await service.GetAllAsync());

        [HttpGet("{patientId:int}/{doctorId:int}")]
        public async Task<IActionResult> GetByKey(int patientId, int doctorId, DateTime appointmentDate)
        {
            var result = await service.GetAsync(patientId, doctorId, appointmentDate);
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentRequest request)
        {
            var result = await service.CreateAsync(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetByKey),
                new { patientId = request.PatientId, doctorId = request.DoctorId, appointmentDate = request.AppointmentDate },
                result);
        }

        [HttpDelete("{patientId:int}/{doctorId:int}")]
        public async Task<IActionResult> Delete(int patientId, int doctorId, DateTime appointmentDate)
        {
            var result = await service.DeleteAsync(patientId, doctorId, appointmentDate);
            return result.IsSuccess ? NoContent() : NotFound(result);
        }
    }
}