using Microsoft.EntityFrameworkCore;
using PopCorn.DataLayer.Models;

namespace PopCorn.DataLayer.Context
{
    public class PopCornDbContext : DbContext
    {
        public PopCornDbContext(DbContextOptions<PopCornDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Project> Projects { get; set; }
	    public virtual DbSet<ProjectStatus> ProjectStatuses { get; set; }
		public virtual DbSet<FinanceCategory> FinanceCategories { get; set; }
        public virtual DbSet<FinanceType> FinanceTypes { get; set; }
        public virtual DbSet<ProjectFinance> ProjectFinances { get; set; }
	    public virtual DbSet<User> Users { get; set; }
	    public virtual DbSet<Role> Roles { get; set; }
	    public virtual DbSet<UserProject> UserProjects { get; set; }
	}
}