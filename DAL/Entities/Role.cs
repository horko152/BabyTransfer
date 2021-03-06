﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
	[Table("roles")]
	public class Role
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[JsonIgnore]
		public ICollection<User> Users { get; set; }
	}
}
