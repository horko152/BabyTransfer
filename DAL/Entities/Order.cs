using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
	[Table("orders")]
	public class Order
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; set; }

		[Column("customer_id")]
		public int? CustomerId { get; set; }

		[Column("status")]
		public string Status { get; set; }

		[Column("driver_id")]
		public int? DriverId { get; set; }

		[Column("timeofcall")]
		public DateTime TimeOfCall { get; set; }

		[Column("city")]
		public string City { get; set; }

		[Column("addressofcall")]
		public string AddressOfCall { get; set; }

		[Column("addressoftransfer")]
		public string AddressOfTransfer { get; set; }

		[Column("vehicletype")]
		public string VehicleType { get; set; }

		[Column("listofchildren")]
		public ICollection<Child> Children { get; set; }

		[Column("backandforth")]
		public bool BackAndForth { get; set; }

		[Column("comment")]
		public string Comment { get; set; }

		[Column("distance")]
		public double Distance { get; set; }

		[Column("arrivaltime")]
		public DateTime ArrivalTime { get; set; }

		[Column("cost")]
		public decimal Cost { get; set; }

		[ForeignKey("CustomerId")]
		[JsonIgnore]
		public Customer Customer { get; set; }

		[ForeignKey("DriverId")]
		[JsonIgnore]
		public Driver Driver { get; set; }
	}
}
