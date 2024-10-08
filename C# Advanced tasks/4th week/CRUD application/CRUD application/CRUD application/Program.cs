﻿using CRUD_application;
using System;
using System.Diagnostics;
using System.Threading.Channels;
using System.Threading.Tasks;
namespace CRUD_implementation
{
    class main_class
    {
        static async Task Main(string[] args)
        {
            CRUD obj = new CRUD();
            hub(obj);
        }
        private static void hub(CRUD obj)
        {
            int table_id = 0;
            //delegates and lambda expressions
            Dictionary<string, Action> CRUD_user_operations = new Dictionary<string, Action>()
            {
                {"1",()=>obj.create_user() },
                {"2",()=>obj.read_user() },
                {"3",()=>obj.update_user() },
                {"4",()=>obj.delete_user() }
            };
            Dictionary<string, Action> CRUD_table_operations = new Dictionary<string, Action>()
            {
                {"1",()=>obj.create_table()},
                {"2",()=>obj.delete_table()}
            };
            while (true)
            {
                Console.WriteLine("choose the number of method you want:\n1-create new table\n2-delete table");
                string chosen_num = Console.ReadLine();
                CRUD_table_operations[chosen_num].Invoke();
                while (true)
                {
                    Console.WriteLine("choose the number of the method you want:\n1- create \n2- read\n3- update\n4- delete\n5-exit\n");
                    chosen_num = Console.ReadLine();
                    if (chosen_num == "5")
                        break;
                    CRUD_user_operations[chosen_num].Invoke();
                }
            }
        }
    }
}
