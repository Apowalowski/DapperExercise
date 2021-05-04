using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace BestBuyCRUDPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Configuration
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            #endregion Console.WriteLine(connString);
            IDbConnection conn = new MySqlConnection(connString);
            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);
            Console.WriteLine("Hello user these are our departments");
            Console.WriteLine("please press enter ...");
            var depos = repo.GetAllDepartments();
            Print(depos);
            Console.WriteLine("Do you want a department?");
            string userResponse = Console.ReadLine();
            if(userResponse.ToLower() == "yes")
            {
                Console.WriteLine("what is the name of your department?");
                userResponse = Console.ReadLine();

                repo.InsertDepartment(userResponse);
                Print(repo.GetAllDepartments());
            }
            Console.WriteLine("Have a nice day!");
        }
        private static void Print(IEnumerable<Department> depos)
        {
            foreach (var depo in depos)
            {
                Console.WriteLine($"{depo.Name} {depo.DepartmentID}");
            }
        }
    }
}
