﻿using System.Collections.Generic;
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
			return _context.Users.Include(u => u.Role).Include(u => u.Projects.Select(p => p.Project)).ToList();
		}

		public User GetUser(int id)
		{
			return _context.Users.Include(u => u.Role).Include(u => u.Projects.Select(p => p.Project))
				.FirstOrDefault(p => p.Id == id);
		}

		public User GetUser(string email)
		{
			return _context.Users.Include(u => u.Role).Include(u => u.Projects.Select(p => p.Project))
				.FirstOrDefault(u => u.Email == email);
		}

		public User GetUser(string email, string password)
		{
			return _context.Users.Include(u => u.Role).Include(u => u.Projects.Select(p => p.Project))
				.FirstOrDefault(u => u.Email == email && u.Password == password);
		}

		public bool Edit(User user)
		{
			if (user.Id == 0)
			{
				if (GetUser(user.Email) == null)
				{
					_context.Add(user);
				}
				else
				{
					return false;
				}
			}
			else
			{
				_context.Update(user);
			}

			_context.SaveChanges();

			return true;
		}
	}
}