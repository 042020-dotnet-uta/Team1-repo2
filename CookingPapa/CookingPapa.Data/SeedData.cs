using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CookingPapa.Domain.Models;

namespace CookingPapa.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CookingpapaContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CookingpapaContext>>()))
            {
                // look for any product/store in the DB
                if (context.User.Any())
                {
                    return; // DB already has something
                }

                context.User.AddRange(
                    new User
                    {
                        Email = "seedTest@gmail.com",
                        Username = "seedTest",
                        Password = "testSeed"
                    }, 
                    new User
                    {
                        Email = "seedTest2@test.com",
                        Username = "seedTest2",
                        Password = "testSeed2"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
