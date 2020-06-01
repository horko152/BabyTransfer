using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
	[Table("times")]
	public class Time
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; set; }

		[Column("startworking")]
		public TimeSpan StartWorking { get; set; }

		[Column("stopworking")]
		public TimeSpan StopWorking { get; set; }

		[Column("pausefrom")]
		public TimeSpan PauseFrom { get; set; }

		[Column("pauseto")]
		public TimeSpan PauseTo { get; set; }

		[JsonIgnore]
		public ICollection<Driver> Drivers { get; set; }
	}
}
