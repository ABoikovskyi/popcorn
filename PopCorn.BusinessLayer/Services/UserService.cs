using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PopCorn.DataLayer.Context;
using PopCorn.DataLayer.Models;

namespace PopCorn.BusinessLayer.Services
{
	public class UserService
	{
		private readonly PopCornDbContext _context;

		public UserService(PopCornDbContext context)
		{
			_context = context;
		}

		public List<User> GetUsers()
		{
			return _context.Users.Include(u => u.Role).Include(u => u.UserProjects).ThenInclude(p => p.Project)
				.ToList();
		}

		public User GetUser(int id)
		{
			return _context.Users.Include(u => u.Role).Include(u => u.UserProjects).ThenInclude(p => p.Project)
				.FirstOrDefault(p => p.Id == id);
		}

		public User GetUser(string email)
		{
			return _context.Users.Include(u => u.Role).Include(u => u.UserProjects).ThenInclude(p => p.Project)
				.FirstOrDefault(u => u.Email == email);
		}

		public User GetUser(string email, string password)
		{
			return _context.Users.Include(u => u.Role).Include(u => u.UserProjects).ThenInclude(p => p.Project)
				.FirstOrDefault(u => u.Email == email && u.Password == password);
		}

		public bool Edit(User user)
		{
			if (user.Id == 0)
			{
				if (GetUser(user.Email) == null)
				{
					_context.Add(user);
					_context.SaveChanges();
					foreach (var projectId in user.ProjectsIds)
					{
						_context.Add(new UserProject {UserId = user.Id, ProjectId = projectId});
					}
				}
				else
				{
					return false;
				}
			}
			else
			{
				var userProjects = _context.UserProjects.Where(up => up.UserId == user.Id).ToList();
				foreach (var project in userProjects.Where(up => !user.ProjectsIds.Contains(up.ProjectId)))
				{
					_context.Remove(project);
				}

				foreach (var projectId in user.ProjectsIds.Where(p => userProjects.All(up => up.ProjectId != p)))
				{
					_context.Add(new UserProject { UserId = user.Id, ProjectId = projectId });
				}

				_context.Update(user);
			}

			_context.SaveChanges();

			return true;
		}
	}
}