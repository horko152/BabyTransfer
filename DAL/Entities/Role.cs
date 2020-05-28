using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
	public static class Role
	{
        public const string Admin = "Admin";
        public const string Driver = "Driver";
        public const string Customer = "Customer";
    }
}
