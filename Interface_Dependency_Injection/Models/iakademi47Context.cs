using Microsoft.EntityFrameworkCore;

namespace Interface_Dependency_Injection.Models
{
	public class iakademi47Context : DbContext
	{
		public iakademi47Context(DbContextOptions<iakademi47Context> options) : base(options)
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

			var configuration = builder.Build();

			optionsBuilder.UseSqlServer(configuration["ConnectionStrings:iakademi47Connection"]);
		}

		public DbSet<Product> Products { get; set; }

	}
      
    
}
