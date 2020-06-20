using Artillery.Data.File;
using Artillery.Data.Repositories;
using Artillery.Domain.Entity;
using Npgsql;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Artillery
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string conn = "Server = 127.0.0.1; Port = 5432; Database = postgres; User Id = postgres; Password = postgres@2020;";
            var usersRepository = new UserRepository(new NpgsqlConnection(conn));
            var csvReader = new CsvReader(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\", @"Dev\Resources\Data.csv"));

            var data = csvReader.ReadFile();

            foreach (User user in data)
            {
                await usersRepository.AddUser(user);
            }

            var users = await usersRepository.GetAll();

            users.ForEach(user =>
            {
                Console.WriteLine(user);
            });

            csvReader.CleanUp();
        }
    }
}
