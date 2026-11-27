
using AutoMapper;
using HealthCareSystem.BLL.DTOs;
using HealthCareSystem.BLL.Services;
using HealthCareSystem.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareSystem.PL.Controllers
{
    public class PatientsController(
        IPatientService patientService,
        IMapper mapper) : Controller
    {
        private const int PageSize = 5;

        public async Task<IActionResult> Index(string? searchTerm, int pageIndex = 1)
        {
            var result = await patientService.GetAllAsync();

            if (!result.IsSuccess || result.Value is null)
                return View(new PatientIndexViewModel());

            var patients = mapper.Map<IEnumerable<PatientViewModel>>(result.Value);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                patients = patients.Where(p =>
                    p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            var patientsList = patients.ToList();

            var totalCount = patientsList.Count;
            var totalPages = (int)Math.Ceiling(totalCount / (double)PageSize);

            pageIndex = Math.Max(1, pageIndex);

            if (totalPages > 0)
                pageIndex = Math.Min(pageIndex, totalPages);
            else
                pageIndex = 1;

            var model = new PatientIndexViewModel
            {
                Patients = patientsList
                    .Skip((pageIndex - 1) * PageSize)
                    .Take(PageSize)
                    .ToList(),

                SearchTerm = searchTerm,
                PageIndex = pageIndex,
                TotalPages = totalPages
            };

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var request = mapper.Map<CreatePatientRequest>(model);
            var result = await patientService.CreateAsync(request);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Error ?? "Unable to create patient.");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await patientService.GetByIdAsync(id);

            if (!result.IsSuccess || result.Value is null)
                return NotFound();

            var model = mapper.Map<PatientViewModel>(result.Value);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PatientViewModel model)
        {
            if (id != model.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(model);

            var request = mapper.Map<UpdatePatientRequest>(model);
            var result = await patientService.UpdateAsync(request);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Error ?? "Unable to update patient.");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        // Details
        public async Task<IActionResult> Details(int id)
        {
            var result = await patientService.GetByIdAsync(id);

            if (!result.IsSuccess || result.Value is null)
                return NotFound();

            var model = mapper.Map<PatientViewModel>(result.Value);

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await patientService.GetByIdAsync(id);

            if (!result.IsSuccess || result.Value is null)
                return NotFound();

            var model = mapper.Map<PatientViewModel>(result.Value);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await patientService.DeleteAsync(id);

            if (!result.IsSuccess)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
