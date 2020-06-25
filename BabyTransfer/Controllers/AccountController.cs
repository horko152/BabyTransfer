using BabyTransfer.Security;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BabyTransfer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : Controller
	{
		private List<Role> Roles = new List<Role>
		{
			new Role { Id = 1, Name = "Admin"},
			new Role { Id =2 , Name = "Driver"},
			new Role { Id = 3, Name = "Customer"}
		};
		private List<User> Users = new List<User>
		{
			new User { Id = 1, FirstName = "Igor", LastName = "Voloshenyuk", Email ="voloshenyuk98@gmail.com", Password = "horko1111",Role = new Role { Id = 1, Name = "Admin"}},
			new User { Id = 2, FirstName="Stas", LastName="Sheikin", Email = "stas@gmail.com", Password="stas1111", Role = new Role { Id =2 , Name = "Driver" } }
		};

		[HttpGet("/users")]
		public IActionResult GetAllUsers()
		{
			return Ok(Users);
		}

		[AllowAnonymous]
		[HttpPost("/login")]

		public IActionResult Login([FromBody] LoginCredentials credentials)
		{
			var user = Users.FirstOrDefault(x => x.Email == credentials.Email);

			if (user != null)
			{
				if (user.Password.Equals(credentials.Password))
				{
					var claims = new List<Claim>
					{
						new Claim("Email", user.Email),
						new Claim("Id", user.Id.ToString()),
						new Claim("Role", user.Role.Name.ToString())
					};

					var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthOptions.SIGNING_KEY));
					var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

					var token = new JwtSecurityToken(
						issuer: "https://localhost:44385/",
						audience: "https://localhost:44385/",
						claims: claims,
						expires: DateTime.Now.AddDays(1),
						signingCredentials: creds);

					var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

					Request.HttpContext.Response.Headers.Add("Authorization", "Bearer " + encodedToken);
					var responce = new
					{
						token = encodedToken,
						id = user.Id,
						firstname = user.FirstName,
						lastname = user.LastName,
						role = user.Role.Name.ToString()
					};
					return Json(responce);
				}
				return BadRequest("Wrong email or password");
			}
			return BadRequest("Could not create token");
		}
		[AllowAnonymous]
		[HttpPost("/registration")]
		public IActionResult Registation([FromBody] RegistrCredentials credentials)
		{
			User user = Users.FirstOrDefault(x => x.Email == credentials.Email);
			if (user == null)
			{
				var firstSpaceIndex = credentials.Name.IndexOf(" ");
				var FirstName = credentials.Name.Substring(0, firstSpaceIndex);
				var LastName = credentials.Name.Substring(firstSpaceIndex + 1);
				Users.Add(new User { FirstName = FirstName, LastName = LastName, Email = credentials.Email, Password = credentials.Password, Role = new Role { Id = 3, Name = "Customer" } });
				return Login(new LoginCredentials { Email = credentials.Email, Password = credentials.Password });
			}
			else
			{
				return BadRequest("Email is used");
			}
		}

	}
}
