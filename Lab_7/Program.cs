using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

public class Program
{
    static void Main(string[] args)
    {
        var task = PerformDatabaseOperations();

        Console.WriteLine("Quote of the day");
        Console.WriteLine(" Don't worry about the world coming to an end today... ");
        Console.WriteLine(" It's already tomorrow in Australia.");

        task.Wait();

        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    public static async Task PerformDatabaseOperations()
    {
        string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=blogdb;Integrated Security=True";

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

            // Write all users out to Console
            Console.WriteLine("Query completed with following results:");
            foreach (var user in users)
            {
                Console.WriteLine(" - " + user.FirstName);
            }
        }
    }
}
