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
		public List<DateTime> Children { get; set; }
		[Column("inbothways")]
		public bool InBothWays { get; set; }
		[Column("comment")]
		public string Comment { get; set; }
		//[JsonIgnore]
		[Column("customer_id")]
		public int Customer_Id { get; set; }

		[ForeignKey("Customer_Id")]
		[JsonIgnore]
		public Customer Customer { get; set; }
		//[JsonIgnore]
		[Column("driver_id")]
		public int Driver_Id { get; set; }

		[ForeignKey("Driver_Id")]
		[JsonIgnore]
		public Driver Driver { get; set; }
	}
}
