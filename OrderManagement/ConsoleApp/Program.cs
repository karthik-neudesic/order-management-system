﻿using OrderManagement.Repository;
using OrderManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new OrderManagementDBContext())
            {
                //var stud = new Role() { Name = "Bill" };

                var role = ctx.Roles.First();
                Console.WriteLine(role.Name);
                //ctx.SaveChanges();
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}