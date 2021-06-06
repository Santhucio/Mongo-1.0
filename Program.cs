using System.Collections.Generic;
using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoBD1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataManager = new DataManager("mongodb://localhost:27017", "seminar");
            
            while (true)
            {
                string input;
                while ((input = Console.ReadLine()) != null)
                {
                    string[] words = input.Split(' ');
                    
                    if(words.Length == 2)
                    {
                        if (words[0] == "manufacture") //manufacture Ford
                        {
                            var typedManufacture = dataManager.GetCarsByNameTyped(words[1]);
                            int count = 0;
                            Console.WriteLine("---------"); 
                            foreach (var user in typedManufacture)
                            {
                                if (user.Model != null)
                                {
                                    Console.Write(user.Model);
                                }
                                else
                                {
                                    Console.Write("UnknownModel");
                                }
                                Console.Write(" ");
                                if (user.Year != 0)
                                {
                                    Console.WriteLine(user.Year);
                                }
                                else
                                {
                                    Console.WriteLine("UnknownYear");
                                }
                                count++;
                            }
                            Console.WriteLine("---------"); 
                            Console.Write("Count = ");
                            Console.WriteLine(count);
                        }
                        else if (words[0] == "later_then") // later_then 2009
                        {
                            var typedYear = dataManager.GetCarsByYearTyped(Int32.Parse(words[1]));
                            Console.WriteLine("---------"); 
                            foreach (var user in typedYear)
                            {
                                if (user.Manufacture != null)
                                {
                                    Console.Write(user.Manufacture);
                                }
                                else
                                {
                                    Console.Write("UnknownManufacture");
                                }
                                Console.Write(" ");
                                if (user.Year != 0)
                                {
                                    Console.WriteLine(user.Year);
                                }
                                else
                                {
                                    Console.WriteLine("UnknownYear");
                                }
                            }
                            Console.WriteLine("---------"); 
                        }
                        else if (words[0] == "options") //60bb6db96628c03b58f3496b 60bb6db96628c03b58f348e1 
                        {
                            var typedId = dataManager.GetCarsByOptionsTyped(words[1]);                                
                            foreach (var user in typedId)
                            {
                                Console.WriteLine("---------"); 
                                foreach (var u in user.Car_options)
                                {
                                    Console.Write("- ");
                                    Console.WriteLine(u);
                                }
                                Console.WriteLine("---------"); 
                            }
                        }
                        else
                        {
                            Console.WriteLine("Unknown command");
                        }
                    }
                    if (words[0] == "help")
                    {
                        Console.WriteLine("manufacture <name> - количество автомобилей производителя <name>");
                        Console.WriteLine("later_then <year>  - посмотреть все автомобили, выпущенные раньше <year> года");
                        Console.WriteLine("options <id>       - список опций автомобиля с таким <id>");
                    }
                }
            }
        }
    }
}
