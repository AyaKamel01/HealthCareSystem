using AutoMapper;
using HealthCareSystem.BLL.DTOs;
using HealthCareSystem.BLL.Services;
using HealthCareSystem.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareSystem.PL.Controllers
{
    public class DoctorsController(
        IDoctorService doctorService,
        IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var result = await doctorService.GetAllAsync();

            if (!result.IsSuccess)
                return View(Enumerable.Empty<DoctorViewModel>());

            var doctors = mapper.Map<IEnumerable<DoctorViewModel>>(result.Value);

            return View(doctors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var request = mapper.Map<CreateDoctorRequest>(model);
            var result = await doctorService.CreateAsync(request);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Error ?? "Unable to create doctor.");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await doctorService.GetByIdAsync(id);

            if (!result.IsSuccess || result.Value is null)
                return NotFound();

            var model = mapper.Map<DoctorViewModel>(result.Value);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DoctorViewModel model)
        {
            if (id != model.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(model);

            var request = mapper.Map<UpdateDoctorRequest>(model);
            var result = await doctorService.UpdateAsync(request);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Error ?? "Unable to update doctor.");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await doctorService.GetByIdAsync(id);

            if (!result.IsSuccess || result.Value is null)
                return NotFound();

            var model = mapper.Map<DoctorViewModel>(result.Value);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await doctorService.DeleteAsync(id);

            if (!result.IsSuccess)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}