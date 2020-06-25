using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
	[Table("cities")]
	public class City
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; set; }

		[Column("city")]
		public string CityName { get; set; }

		public ICollection<Address> Addresses { get; set; }

		public ICollection<Order> Orders { get; set; }
	}
}
