using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PopCorn.BusinessLayer.Services;
using PopCorn.DataLayer.Attributes;
using PopCorn.DataLayer.Models;

namespace PopCorn.Controllers
{
	//[Authorize]
	public class ProjectController : Controller
	{
		private readonly ProjectService _projectService;
		private readonly FinanceService _financeService;
		private readonly TypeService _typeService;

		public ProjectController(ProjectService projectService, FinanceService financeService, TypeService typeService)
		{
			_projectService = projectService;
			_financeService = financeService;
			_typeService = typeService;
		}

		public IActionResult Index()
		{
			ViewBag.TableTypeStructure = _typeService.GetTypeStructure(typeof(Project), typeof(TableView));
			return View(_projectService.GetProjects());
		}

		public IActionResult Edit(int? id)
		{
			ViewBag.FormTypeStructure = _typeService.GetTypeStructure(typeof(Project), typeof(InputView));
			ViewBag.TableTypeStructure = _typeService.GetTypeStructure(typeof(ProjectFinance), typeof(TableView));
			ViewBag.ProjectFinances = _financeService.GetFinances(id);
			return View(id.HasValue ? _projectService.GetProject(id.Value) : new Project());
		}

		[HttpPost]
		public IActionResult Edit(Project project)
		{
			_projectService.Edit(project);
			return RedirectToAction("Index");
		}
	}
}