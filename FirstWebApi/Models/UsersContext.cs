using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FirstWebApi.Models
{
	public class UsersContext : DbContext
	{
		public DbSet<User> Users { get; set; }


		public UsersContext(DbContextOptions<UsersContext> options)
			: base(options)
		{

		}

	}
}
