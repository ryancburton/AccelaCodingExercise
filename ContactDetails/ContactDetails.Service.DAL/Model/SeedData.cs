using ContactDetails.Service.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ContactDetails.Service.DAL.Model
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ContactDetailsContext(serviceProvider.GetRequiredService<DbContextOptions<ContactDetailsContext>>()))
            {
                if (context.Person.Any())
                {
                    return;
                }

                context.Person.AddRange(
                                        new Person
                                        {
                                            firstName = "Bruce",
                                            lastName = "Wayne"
                                        },
                                        new Person
                                        {
                                            firstName = "Harvey",
                                            lastName = "Dent"
                                        });
                context.SaveChanges();

                if (context.Address.Any())
                {
                    return;
                }

                context.Address.AddRange(
                                        new Address
                                        {
                                            street = "1 Bat Cave",
                                            city = "Gotham",
                                            state = "Make Believe",
                                            postalCode = "BATS001",
                                            PersonId = 1
                                        },
                                        new Address
                                        {
                                            street = "Wayne Mansion",
                                            city = "Gotham",
                                            state = "Make Believe",
                                            postalCode = "Rich123",
                                            PersonId = 1
                                        },
                                        new Address
                                        {
                                            street = "DA Office",
                                            city = "Gotham",
                                            state = "Make Believe",
                                            postalCode = "LAW01",
                                            PersonId = 2
                                        });
                context.SaveChanges();
            }
        }
    }
}


