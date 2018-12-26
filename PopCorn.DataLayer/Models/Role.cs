﻿using System.Collections.Generic;
using PopCorn.DataLayer.Models.Interfaces;

namespace PopCorn.DataLayer.Models
{
	public class Role : IDictionaryEntity
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public virtual List<User> Users { get; set; }
	}
}