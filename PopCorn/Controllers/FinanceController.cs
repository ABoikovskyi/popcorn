using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PopCorn.BusinessLayer.Services;
using PopCorn.DataLayer.Attributes;
using PopCorn.DataLayer.Models;

namespace PopCorn.Controllers
{
	[Authorize]
	public class FinanceController : BaseController
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
			ViewBag.TableTypeStructure = _typeService.GetTypeStructure(typeof(ProjectFinance), typeof(TableView));
			return View(_financeService.GetFinances());
		}

		public IActionResult Edit(int? id, int? projectId)
		{
			ViewBag.FormTypeStructure = _typeService.GetTypeStructure(typeof(ProjectFinance), typeof(InputView));
			ViewBag.FromProject = projectId.HasValue;
			return View(id.HasValue
				? _financeService.GetFinanceOperation(id.Value)
				: new ProjectFinance {Project = new Project {Id = projectId ?? -1}});
		}

		[HttpPost]
		public IActionResult Edit(ProjectFinance projectFinance)
		{
			_financeService.Edit(projectFinance);
			return projectFinance.FromProject
				? RedirectToAction("Edit", "Project", new {id = projectFinance.ProjectId })
				: RedirectToAction("Index");
		}
	}
}