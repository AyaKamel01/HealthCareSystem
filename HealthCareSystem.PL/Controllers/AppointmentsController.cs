using AutoMapper;
using HealthCareSystem.BLL.DTOs;
using HealthCareSystem.BLL.Services;
using HealthCareSystem.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealthCareSystem.PL.Controllers
{
    public class AppointmentsController(
        IAppointmentService appointmentService,
        IPatientService patientService,
        IDoctorService doctorService,
        IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var result = await appointmentService.GetAllAsync();

            if (!result.IsSuccess)
                return View(Enumerable.Empty<AppointmentViewModel>());

            var appointments =
                mapper.Map<IEnumerable<AppointmentViewModel>>(result.Value);

            return View(appointments);
        }

        public async Task<IActionResult> Create()
        {
            var model = new AppointmentViewModel();

            await LoadLists(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await LoadLists(model);
                return View(model);
            }

            var request = mapper.Map<CreateAppointmentRequest>(model);
            var result = await appointmentService.CreateAsync(request);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(
                    string.Empty,
                    result.Error ?? "Unable to create appointment.");

                await LoadLists(model);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task LoadLists(AppointmentViewModel model)
        {
            var patientsResult = await patientService.GetAllAsync();
            var doctorsResult = await doctorService.GetAllAsync();

            model.Patients = patientsResult.IsSuccess
                ? patientsResult.Value!.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                : Enumerable.Empty<SelectListItem>();

            model.Doctors = doctorsResult.IsSuccess
                ? doctorsResult.Value!.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                })
                : Enumerable.Empty<SelectListItem>();
        }
    }
}