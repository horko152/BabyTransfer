using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
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

		[Column("number")]
		public string Number { get; set; }

		[Column("description")]
		public string Description { get; set; }

		[JsonIgnore]
		public ICollection<Driver> Drivers { get; set; }
	}
}
