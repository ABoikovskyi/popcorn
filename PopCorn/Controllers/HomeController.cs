using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PopCorn.BusinessLayer.Services;
using PopCorn.DataLayer.Attributes;
using PopCorn.DataLayer.Models;
using PopCorn.Models;

namespace PopCorn.Controllers
{
	//[Authorize]
	public class HomeController : Controller
	{
		private readonly ProjectService _projectService;
		private readonly FinanceService _financeService;
		private readonly TypeService _typeService;

		public HomeController(ProjectService projectService, FinanceService financeService, TypeService typeService)
		{
			_projectService = projectService;
			_financeService = financeService;
			_typeService = typeService;
		}

		public IActionResult Structure()
		{
			ViewBag.ProjectStatusStructure = _typeService.GetTypeStructure(typeof(ProjectStatus), typeof(TableView));
			ViewBag.FinanceTypeStructure = _typeService.GetTypeStructure(typeof(FinanceType), typeof(TableView));
			ViewBag.FinanceCategoryStructure = _typeService.GetTypeStructure(typeof(FinanceCategory), typeof(TableView));
			ViewBag.ProjectStatuses = _projectService.GetStatuses();
			ViewBag.FinanceTypes = _financeService.GetFinanceTypes();
			ViewBag.FinanceCategories = _financeService.GetFinanceCategories();
			return View();
		}

		public IActionResult EditStatus(int? id)
		{
			ViewBag.FormTypeStructure = _typeService.GetTypeStructure(typeof(ProjectStatus), typeof(InputView));
			return View(id.HasValue ? _projectService.GetStatus(id.Value) : new ProjectStatus());
		}

		[HttpPost]
		public IActionResult EditStatus(ProjectStatus status)
		{
			_projectService.EditStatus(status);
			return RedirectToAction("Structure");
		}

		public IActionResult EditType(int? id)
		{
			ViewBag.FormTypeStructure = _typeService.GetTypeStructure(typeof(FinanceType), typeof(InputView));
			return View(id.HasValue ? _financeService.GetFinanceType(id.Value) : new FinanceType());
		}

		[HttpPost]
		public IActionResult EditType(FinanceType type)
		{
			_financeService.EditType(type);
			return RedirectToAction("Structure");
		}

		public IActionResult EditCategory(int? id)
		{
			ViewBag.FormTypeStructure = _typeService.GetTypeStructure(typeof(FinanceCategory), typeof(InputView));
			return View(id.HasValue ? _financeService.GetFinanceCategory(id.Value) : new FinanceCategory());
		}

		[HttpPost]
		public IActionResult EditCategory(FinanceCategory category)
		{
			_financeService.EditCategory(category);
			return RedirectToAction("Structure");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
		}
	}
}