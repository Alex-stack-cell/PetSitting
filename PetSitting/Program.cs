
using System;
using System.Collections.Generic;
using System.Reflection;
using DALPetSitting;
using DALPetSitting.Services;
using DALPetSitting.Entities;
using DALPetSitting.Infra;

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

        }
    }
}
