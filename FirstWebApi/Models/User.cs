using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebApi.Models
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		[Required]
		[StringLength(100)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(100)]
		public string LastName { get; set; }

		[StringLength(100)]
		public string MiddleName { get; set; }
	}
}
