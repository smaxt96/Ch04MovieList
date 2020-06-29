using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch04MovieList.Models
{
    public class OlympicsModel
    {
		public class Category
		{
			public string CategoryID { get; set; }
			public string Name { get; set; }
		}

		public class Game
		{
			public string GameID { get; set; }
			public string Name { get; set; }
		}

		public class Country
		{
			public string CountryID { get; set; }
			public string Name { get; set; }
			public Category Category { get; set; }
			public Game Game { get; set; }
			public string FlagImage { get; set; }
		}

		public class CountryContext : DbContext
		{
			public CountryContext(DbContextOptions<CountryContext> options)
				: base(options) { }

			public DbSet<Country> Countries { get; set; }
			public DbSet<Category> Categories { get; set; }
			public DbSet<Game> Games { get; set; }

			protected override void OnModelCreating(ModelBuilder modelBuilder)
			{
				base.OnModelCreating(modelBuilder);

				modelBuilder.Entity<Category>().HasData(
					new Category { CategoryID = "in", Name = "Indoor" },
					new Category { CategoryID = "out", Name = "Outdoor" });

				modelBuilder.Entity<Game>().HasData(
					new Game { GameID = "winter", Name = "Winter Olympics" },
					new Game { GameID = "summer", Name = "Summer Olympics" },
					new Game { GameID = "paralympics", Name = "Paralympics" },
					new Game { GameID = "youth", Name = "Youth Olympics" });

				modelBuilder.Entity<Country>().HasData(
					new { CountryID = "at", Name = "Austria", CategoryID = "out", GameID = "paralympics", FlagImage = "flag-of-Austria.png" },
					new { CountryID = "br", Name = "Brazil", CategoryID = "out", GameID = "summer", FlagImage = "flag-of-Brazil.png" },
					new { CountryID = "ca", Name = "Canada", CategoryID = "in", GameID = "winter", FlagImage = "flag-of-Canada.png" },
					new { CountryID = "cn", Name = "China", CategoryID = "in", GameID = "summer", FlagImage = "flag-of-China.png" },
					new { CountryID = "cy", Name = "Cyprus", CategoryID = "in", GameID = "youth", FlagImage = "flag-of-Cyprus.png" },
					new { CountryID = "fi", Name = "Finland", CategoryID = "out", GameID = "youth", FlagImage = "flag-of-Finland.png" },
					new { CountryID = "fr", Name = "France", CategoryID = "in", GameID = "youth", FlagImage = "flag-of-France.png" },
					new { CountryID = "de", Name = "Germany", CategoryID = "in", GameID = "summer", FlagImage = "flag-of-Germany.png" },
					new { CountryID = "gb", Name = "Great Britain", CategoryID = "in", GameID = "winter", FlagImage = "flag-of-Great-Britain.png" },
					new { CountryID = "it", Name = "Italy", CategoryID = "out", GameID = "winter", FlagImage = "flag-of-Italy.png" },
					new { CountryID = "jm", Name = "Jamaica", CategoryID = "out", GameID = "winter", FlagImage = "flag-of-Jamaica.png" },
					new { CountryID = "jp", Name = "Japan", CategoryID = "out", GameID = "winter", FlagImage = "flag-of-Japan.png" },
					new { CountryID = "mx", Name = "Mexico", CategoryID = "in", GameID = "summer", FlagImage = "flag-of-Mexico.png" },
					new { CountryID = "nl", Name = "Netherlands", CategoryID = "out", GameID = "summer", FlagImage = "flag-of-Netherlands.png" },
					new { CountryID = "pk", Name = "Pakistan", CategoryID = "out", GameID = "paralympics", FlagImage = "flag-of-Pakistan.png" },
					new { CountryID = "pt", Name = "Portugal", CategoryID = "out", GameID = "youth", FlagImage = "flag-of-Portugal.png" },
					new { CountryID = "ru", Name = "Russia", CategoryID = "in", GameID = "youth", FlagImage = "flag-of-Russia.png" },
					new { CountryID = "sk", Name = "Slovakia", CategoryID = "out", GameID = "youth", FlagImage = "flag-of-Slovakia.png" },
					new { CountryID = "se", Name = "Sweden", CategoryID = "in", GameID = "winter", FlagImage = "flag-of-Sweden.png" },
					new { CountryID = "th", Name = "Thailand", CategoryID = "in", GameID = "paralympics", FlagImage = "flag-of-Thailand.png" },
					new { CountryID = "ua", Name = "Ukraine", CategoryID = "in", GameID = "paralympics", FlagImage = "flag-of-Ukraine.png" },
					new { CountryID = "us", Name = "United States", CategoryID = "out", GameID = "summer", FlagImage = "flag-of-United-States.png" },
					new { CountryID = "uy", Name = "Uruguay", CategoryID = "in", GameID = "paralympics", FlagImage = "flag-of-Uruguay.png" },
					new { CountryID = "zw", Name = "Zimbabwe", CategoryID = "out", GameID = "paralympics", FlagImage = "flag-of-Zimbabwe.png" });
			}
		}
	}
}
