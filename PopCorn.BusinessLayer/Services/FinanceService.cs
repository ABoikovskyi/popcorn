using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PopCorn.DataLayer.Context;
using PopCorn.DataLayer.Models;

namespace PopCorn.BusinessLayer.Services
{
	public class FinanceService
	{
		private readonly PopCornDbContext _context;

		public FinanceService(PopCornDbContext context)
		{
			_context = context;
		}

		public List<ProjectFinance> GetFinances(int? projectId = null)
		{
			return _context.ProjectFinances
				.Include(f => f.FinanceType)
				.Include(f => f.FinanceCategory)
				.Include(f => f.FinanceCategory.ParentCategory)
				.Include(f => f.Project)
				.Where(f => !projectId.HasValue || f.ProjectId == projectId).ToList();
		}

		public ProjectFinance GetFinanceOperation(int id)
		{
			return _context.ProjectFinances
				.Include(f => f.FinanceType)
				.Include(f => f.FinanceCategory)
				.Include(f => f.FinanceCategory.ParentCategory)
				.Include(f => f.Project)
				.First(p => p.Id == id);
		}

		public List<FinanceType> GetFinanceTypes()
		{
			return _context.FinanceTypes.ToList();
		}

		public FinanceType GetFinanceType(int id)
		{
			return _context.FinanceTypes.First(p => p.Id == id);
		}

		public List<FinanceCategory> GetFinanceCategories()
		{
			return _context.FinanceCategories.Include(c => c.ParentCategory).ToList();
		}

		public FinanceCategory GetFinanceCategory(int id)
		{
			return _context.FinanceCategories.First(p => p.Id == id);
		}

		public void Edit(ProjectFinance projectFinance)
		{
			if (projectFinance.Id == 0)
			{
				_context.Add(projectFinance);
			}
			else
			{
				_context.Update(projectFinance);
			}

			_context.SaveChanges();
		}

		public void EditCategory(FinanceCategory category)
		{
			if (category.Id == 0)
			{
				_context.Add(category);
			}
			else
			{
				_context.Update(category);
			}

			_context.SaveChanges();
		}

		public void EditType(FinanceType type)
		{
			if (type.Id == 0)
			{
				_context.Add(type);
			}
			else
			{
				_context.Update(type);
			}

			_context.SaveChanges();
		}
	}
}