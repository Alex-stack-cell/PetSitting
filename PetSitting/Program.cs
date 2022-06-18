
using System;
using System.Collections.Generic;
using System.Reflection;
using DALPetSitting;
using DALPetSitting.Services;
using DALPetSitting.Entities;
using DALPetSitting.Infra;
using DALPetSitting.Helpers;

namespace PetSitting
{
    public class Program
    {
        /// <summary>
        /// Le programme console permet d'effectuer de tester l'application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //string oCon = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PetSitting;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //ConnectionString connectionString = new ConnectionString(oCon);

            //AccountService accountService = new AccountService( connectionString);

            //IEnumerable<Account> list = accountService.GetEmailPetSitter();

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item.Email);
            //}

            byte[] salt = Crypto.GenerateSalt();
            string passwordClear = "Test1234=*";

            string passwordHashed = Crypto.HashPassword(salt, passwordClear);

            Console.WriteLine("Hashed password : "+ passwordHashed + " - Clear Password : " + passwordClear);
            Console.WriteLine(salt is byte[]);
            Console.WriteLine(salt.Length);
            Console.WriteLine(salt.GetType());

        }
    }
}
