using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PopCorn.BusinessLayer.Services;
using PopCorn.DataLayer.Attributes;
using PopCorn.DataLayer.Models;
using System.Collections.Generic;

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

		public IActionResult Index(int? projectId = null)
		{
			ViewBag.TableTypeStructure = _typeService.GetTypeStructure(typeof(ProjectFinance), typeof(TableView));
			if (projectId.HasValue)
			{
				ViewBag.ProjectId = projectId.Value;
				ViewBag.LinkParams = new Dictionary<string, int> {{"projectId", projectId.Value}};
			}

			return View(_financeService.GetFinances(projectId));
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
				? RedirectToAction("Index", "Finance", new {projectId = projectFinance.ProjectId})
				: RedirectToAction("Index");
		}

		public IActionResult Delete(int id, int? projectId)
		{
			_financeService.Delete(id);
			return RedirectToAction("Index", "Finance", new {projectId});
		}
	}
}