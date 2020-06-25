using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
	[Table("vehicletypes")]
	public class VehicleType
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; set; }

		[Column("type")]
		public string Type { get; set; }

		[Column("numberofplaces")]
		public int NumberOfOlaces { get; set; }

		[Column("number")]
		public string Number { get; set; }

		[Column("description")]
		public string Description { get; set; }

		[Column("priceforcall")]
		public decimal PriceForCall { get; set; }

		[Column("priceforkm")]
		public decimal PriceForKm { get; set; }

		[Column("pricefordowntime")]
		public decimal PriceForDownTime { get; set; }

		[JsonIgnore]
		public ICollection<Driver> Drivers { get; set; }

		public ICollection<Order> Orders { get; set; }
	}
}
