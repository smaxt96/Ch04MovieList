﻿// <auto-generated />
using Ch04MovieList.Models.Olympics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ch04MovieList.Migrations.Country
{
    [DbContext(typeof(CountryContext))]
    partial class CountryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ch04MovieList.Models.Game", b =>
                {
                    b.Property<string>("GameID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameID");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            GameID = "winter",
                            Name = "Winter Olympics"
                        },
                        new
                        {
                            GameID = "summer",
                            Name = "Summer Olympics"
                        },
                        new
                        {
                            GameID = "paralympics",
                            Name = "Paralympics"
                        },
                        new
                        {
                            GameID = "youth",
                            Name = "Youth Olympics"
                        });
                });

            modelBuilder.Entity("Ch04MovieList.Models.Olympics.Category", b =>
                {
                    b.Property<string>("CategoryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = "in",
                            Name = "Indoor"
                        },
                        new
                        {
                            CategoryID = "out",
                            Name = "Outdoor"
                        });
                });

            modelBuilder.Entity("Ch04MovieList.Models.Olympics.Country", b =>
                {
                    b.Property<string>("CountryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FlagImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GameID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("GameID");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryID = "at",
                            CategoryID = "out",
                            FlagImage = "flag-of-Austria.png",
                            GameID = "paralympics",
                            Name = "Austria"
                        },
                        new
                        {
                            CountryID = "br",
                            CategoryID = "out",
                            FlagImage = "flag-of-Brazil.png",
                            GameID = "summer",
                            Name = "Brazil"
                        },
                        new
                        {
                            CountryID = "ca",
                            CategoryID = "in",
                            FlagImage = "flag-of-Canada.png",
                            GameID = "winter",
                            Name = "Canada"
                        },
                        new
                        {
                            CountryID = "cn",
                            CategoryID = "in",
                            FlagImage = "flag-of-China.png",
                            GameID = "summer",
                            Name = "China"
                        },
                        new
                        {
                            CountryID = "cy",
                            CategoryID = "in",
                            FlagImage = "flag-of-Cyprus.png",
                            GameID = "youth",
                            Name = "Cyprus"
                        },
                        new
                        {
                            CountryID = "fi",
                            CategoryID = "out",
                            FlagImage = "flag-of-Finland.png",
                            GameID = "youth",
                            Name = "Finland"
                        },
                        new
                        {
                            CountryID = "fr",
                            CategoryID = "in",
                            FlagImage = "flag-of-France.png",
                            GameID = "youth",
                            Name = "France"
                        },
                        new
                        {
                            CountryID = "de",
                            CategoryID = "in",
                            FlagImage = "flag-of-Germany.png",
                            GameID = "summer",
                            Name = "Germany"
                        },
                        new
                        {
                            CountryID = "gb",
                            CategoryID = "in",
                            FlagImage = "flag-of-Great-Britain.png",
                            GameID = "winter",
                            Name = "Great Britain"
                        },
                        new
                        {
                            CountryID = "it",
                            CategoryID = "out",
                            FlagImage = "flag-of-Italy.png",
                            GameID = "winter",
                            Name = "Italy"
                        },
                        new
                        {
                            CountryID = "jm",
                            CategoryID = "out",
                            FlagImage = "flag-of-Jamaica.png",
                            GameID = "winter",
                            Name = "Jamaica"
                        },
                        new
                        {
                            CountryID = "jp",
                            CategoryID = "out",
                            FlagImage = "flag-of-Japan.png",
                            GameID = "winter",
                            Name = "Japan"
                        },
                        new
                        {
                            CountryID = "mx",
                            CategoryID = "in",
                            FlagImage = "flag-of-Mexico.png",
                            GameID = "summer",
                            Name = "Mexico"
                        },
                        new
                        {
                            CountryID = "nl",
                            CategoryID = "out",
                            FlagImage = "flag-of-Netherlands.png",
                            GameID = "summer",
                            Name = "Netherlands"
                        },
                        new
                        {
                            CountryID = "pk",
                            CategoryID = "out",
                            FlagImage = "flag-of-Pakistan.png",
                            GameID = "paralympics",
                            Name = "Pakistan"
                        },
                        new
                        {
                            CountryID = "pt",
                            CategoryID = "out",
                            FlagImage = "flag-of-Portugal.png",
                            GameID = "youth",
                            Name = "Portugal"
                        },
                        new
                        {
                            CountryID = "ru",
                            CategoryID = "in",
                            FlagImage = "flag-of-Russia.png",
                            GameID = "youth",
                            Name = "Russia"
                        },
                        new
                        {
                            CountryID = "sk",
                            CategoryID = "out",
                            FlagImage = "flag-of-Slovakia.png",
                            GameID = "youth",
                            Name = "Slovakia"
                        },
                        new
                        {
                            CountryID = "se",
                            CategoryID = "in",
                            FlagImage = "flag-of-Sweden.png",
                            GameID = "winter",
                            Name = "Sweden"
                        },
                        new
                        {
                            CountryID = "th",
                            CategoryID = "in",
                            FlagImage = "flag-of-Thailand.png",
                            GameID = "paralympics",
                            Name = "Thailand"
                        },
                        new
                        {
                            CountryID = "ua",
                            CategoryID = "in",
                            FlagImage = "flag-of-Ukraine.png",
                            GameID = "paralympics",
                            Name = "Ukraine"
                        },
                        new
                        {
                            CountryID = "us",
                            CategoryID = "out",
                            FlagImage = "flag-of-United-States.png",
                            GameID = "summer",
                            Name = "United States"
                        },
                        new
                        {
                            CountryID = "uy",
                            CategoryID = "in",
                            FlagImage = "flag-of-Uruguay.png",
                            GameID = "paralympics",
                            Name = "Uruguay"
                        },
                        new
                        {
                            CountryID = "zw",
                            CategoryID = "out",
                            FlagImage = "flag-of-Zimbabwe.png",
                            GameID = "paralympics",
                            Name = "Zimbabwe"
                        });
                });

            modelBuilder.Entity("Ch04MovieList.Models.Olympics.Country", b =>
                {
                    b.HasOne("Ch04MovieList.Models.Olympics.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("Ch04MovieList.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameID");
                });
#pragma warning restore 612, 618
        }
    }
}
