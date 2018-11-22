using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PopCorn.DataLayer.Context;
using PopCorn.DataLayer.Models;

namespace PopCorn.BusinessLayer.Services
{
	public class ProjectService
	{
		private readonly PopCornDbContext _context;

		public ProjectService(PopCornDbContext context)
		{
			_context = context;
		}

		public List<Project> GetProjects()
		{
			return _context.Projects.Include(p => p.Status).ToList();
		}

		public Project GetProject(int id)
		{
			return _context.Projects.Include(p => p.Status).First(p => p.Id == id);
		}

		public void Edit(Project project)
		{
			if (project.Id == 0)
			{
				_context.Add(project);
			}
			else
			{
				_context.Update(project);
			}

			_context.SaveChanges();
		}


		public List<ProjectStatus> GetStatuses()
		{
			return _context.ProjectStatuses.ToList();
		}

		public ProjectStatus GetStatus(int id)
		{
			return _context.ProjectStatuses.First(p => p.Id == id);
		}

		public void EditStatus(ProjectStatus status)
		{
			if (status.Id == 0)
			{
				_context.Add(status);
			}
			else
			{
				_context.Update(status);
			}

			_context.SaveChanges();
		}
	}
}