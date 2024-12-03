using Microsoft.EntityFrameworkCore;  // Add this using directive
using System.Linq; // To use .Any()

namespace Szemetszallitas.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            // Get the DbContext from DI container
            var context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<Szemetszallitas.Data.SzemetszallitasContext>();

            // Check if there are any pending migrations and apply them
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            // Seed data if the Products table is empty (example)
            if (!context.Szolgaltatas.Any())
            {
                context.Szolgaltatas.AddRange(
                    new Szolgaltatas
                    {
                        // Id is typically auto-generated, no need to set it manually
                        tipus = "kom",  // Ensure proper casing
                        jelentes = "Kommunális hulladék"
                    },
                    new Szolgaltatas
                    {
                        tipus = "zold",
                        jelentes = "Zöldhulladék"
                    },
                    new Szolgaltatas
                    {
                        tipus = "mua",
                        jelentes = "Műanyag hulladék"
                    },
                    new Szolgaltatas
                    {
                        tipus = "pa",
                        jelentes = "Papír hulladék"
                    }
                );

                context.SaveChanges();  // Don't forget to save changes after adding
            }

            if (!context.Lakig.Any())
            {
                context.Lakig.AddRange(
                    new Lakig
                    {
                        // Id is typically auto-generated, no need to set it manually
                        igeny = new DateTime(2005, 1, 2),  // Use DateTime for initialization
                        mennyiseg = 5,
                        Szolgid = 1  // Assuming "1" refers to an existing `Szolgaltatas` Id
                    },
                    new Lakig
                    {
                        igeny = new DateTime(2005, 2, 15),
                        mennyiseg = 3,
                        Szolgid = 2
                    },
                    new Lakig
                    {
                        igeny = new DateTime(2005, 3, 10),
                        mennyiseg = 10,
                        Szolgid = 3
                    }
                );

               // Don't forget to save changes after adding
            }

            if (!context.Naptar.Any())
            {
                context.Naptar.AddRange(
                    new Naptar
                    {
                        // Id is typically auto-generated, no need to set it manually
                        datum = new DateTime(2005, 1, 2),  // Use DateTime for initialization
                        SzolgId = 1  // Assuming "1" refers to an existing `Szolgaltatas` Id
                    },
                      new Naptar
                      {
                          // Id is typically auto-generated, no need to set it manually
                          datum = new DateTime(2005, 10, 2),  // Use DateTime for initialization
                          SzolgId = 2  // Assuming "1" refers to an existing `Szolgaltatas` Id
                      },
                      new Naptar
                      {
                          // Id is typically auto-generated, no need to set it manually
                          datum = new DateTime(2010, 10, 2),  // Use DateTime for initialization
                          SzolgId = 3  // Assuming "1" refers to an existing `Szolgaltatas` Id
                      }

                );

                // Don't forget to save changes after adding
            }

            context.SaveChanges();

        }
    }
}
