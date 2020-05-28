using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
	[Table("customers")]
	public class Customer : User
	{
		[Column("customeraddress")]
		public string Address { get; set; }
		[Column("lovelyvehicletype")]
		public string VehicleType { get; set; }
		[Column("listofchildren")]
		public List<DateTime> Children { get; set; }
		[JsonIgnore]
		public ICollection<Order> Orders { get; set; }
	}
}
