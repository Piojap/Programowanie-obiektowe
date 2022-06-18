using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

public class Program
{
    static async Task Main(string[] args)
    {
        var task = PerformDatabaseOperations();

        Console.WriteLine("Quote of the day");
        Console.WriteLine(" Don't worry about the world coming to an end today... ");
        Console.WriteLine(" It's already tomorrow in Australia.");

        await task;

        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    public static async Task PerformDatabaseOperations()
    {
        string connectionString = @"Data Source=localhost;Initial Catalog=testowa;Integrated Security=True";

        using (var db = new BloggingContext(connectionString))
        {
            // Create a new user and save it
            db.User.Add(new User
            {
                FirstName = "Piotr",
                LastName = "Japol",
                Age = 22,
                City = "Nowy Targ",
                Etnicity = "Caucasian",
                Gender = "Male"
            });
            Console.WriteLine("Calling SaveChanges.");
            await db.SaveChangesAsync();
            Console.WriteLine("SaveChanges completed.");

            // Query for all users ordered by first name
            Console.WriteLine("Executing query.");
            var users = await (from b in db.User
                               orderby b.FirstName
                               select b).ToListAsync();
            
            User user_select = db.User
                .OrderBy(b => b.Id)
                .First();

            // Update user
            Console.WriteLine("Updating the selected user");
            user_select.FirstName = "Karol";
            user_select.Roles.Add(new Roles { JobName = "Network Admin" });
            db.SaveChanges();

            // Write all users out to Console - 1
            Console.WriteLine("Query completed with following results:");
            foreach (var user in users)
            {
                Console.WriteLine(" - " + user.FirstName);
            }

            // Delete user
            Console.WriteLine("Deleting the user");
            db.Remove(user_select);
            db.SaveChanges();

            // Write all users out to Console - 2
            users = await (from b in db.User
                           orderby b.FirstName
                           select b).ToListAsync();

            Console.WriteLine("Query completed with following results:");
            foreach (var user in users)
            {
                Console.WriteLine(" - " + user.FirstName);
            }
        }
    }
}
