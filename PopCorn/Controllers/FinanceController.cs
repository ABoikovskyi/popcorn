using Microsoft.AspNetCore.Mvc;
using PopCorn.BusinessLayer.Services;
using PopCorn.DataLayer.Attributes;
using PopCorn.DataLayer.Models;

namespace PopCorn.Controllers
{
	public class FinanceController : Controller
	{
		private readonly FinanceService _financeService;
		private readonly TypeService _typeService;

		public FinanceController(FinanceService financeService, TypeService typeService)
		{
			_financeService = financeService;
			_typeService = typeService;
		}

		public IActionResult Index()
		{
			ViewBag.TypeStructure = _typeService.GetTypeStructure(typeof(ProjectFinance), typeof(TableView));
			return View(_financeService.GetFinances());
		}

		public IActionResult Edit(int? id)
		{
			ViewBag.TypeStructure = _typeService.GetTypeStructure(typeof(ProjectFinance), typeof(InputView));
			ViewBag.Finance = _financeService.GetFinances(id);
			return View(id.HasValue ? _financeService.GetFinanceOperation(id.Value) : new ProjectFinance());
		}

		[HttpPost]
		public IActionResult Edit(ProjectFinance projectFinance)
		{
			_financeService.Edit(projectFinance);
			return RedirectToAction("Index");
		}
	}
}