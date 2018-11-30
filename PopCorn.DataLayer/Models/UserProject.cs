using PopCorn.DataLayer.Models.Interfaces;

namespace PopCorn.DataLayer.Models
{
	public class UserProject : IEntity
	{
		public int Id { get; set; }

		public int NameId { get; set; }

		public virtual User Name { get; set; }

		public int ProjectId { get; set; }

		public virtual Project Project { get; set; }
	}
}