using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Ch04MovieList.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    Name = "Sally",
                    PhoneNumber = "515-123-4567",
                    Address = "123 Street St",
                    Note = "New work friend"

                },
                new Contact
                {
                    ContactId = 2,
                    Name = "Pashmina",
                    PhoneNumber = "515-555-1122",
                    Address = "987 Circle Dr",
                    Note = "Neighbor"

                }, new Contact
                {
                    ContactId = 3,
                    Name = "Bernard",
                    PhoneNumber = "515-654-3210",
                    Address = "314 Pie Lane",
                    Note = "Handyman"

                }
               );


        }
    }
}
