using LinQEinfuehrung2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LinQEinfuehrung2
{
    // All the code in this file is included in all platforms.
    public class Program
    {
        // LINQ to Object   ... Abfrage auf Listenartigen Strukturen
        //      Abfrage- und die Erweiterungsmethodensyntax
        // LINQ to XML      ... Abfragen auf XML-Dokumenten
        // LINQ to Entities ... Abfragen auf Daten aus einer Datenbank


        // Lambda-Ausdrücke ... eine kurze Schreibweise für eine Methodendefinition; die Methode hat keinen Namen
        // generische Delegates ... vordefinierte Datentypen auf Methoden (Lambda-Ausdrücke); 
        //      Action<...>, Func<...>, Predicate<...>
        //      return none, return, return boolean


        public static void Main()
        {
            List<Customer> customers = CreateCustomers();
            // Abfragesyntax - SQL-ähnliche Syntax
            // Bsp. alle männlichen Personen ermitteln
            //      selext * from customers where gender = male;
            var customersMale_01 = (from c in customers
                                    where c.Gender == EGender.male
                                    // orderby 
                                    select c).ToList<Customer>();
            // mit einer normalen for-each-Schleife ausgeben
            Console.WriteLine("Alle männlichen Personen ausgeben");
            foreach (Customer c in customersMale_01)
            {
                Console.WriteLine();
            }

            //  mit Hilfe der erweiterungsmethode Foreach + Lambda-Ausdruch ausgeben
            Console.WriteLine("Alle männlichen Personen ausgeben, Lambdaausdruck");
            //customersMale_01.ForEach(c => Console.WriteLine(c));
            customersMale_01.ForEach((Customer c) => { Console.WriteLine(c); });

            // Erweiterungsmethodensyntax - gleiches Beispiel wie oben

            var customersMale_02 = customers
                                    .Where(c => c.Gender == EGender.male)
                                    .ToList<Customer>();
            Console.WriteLine("LINQ-Abfrage mit erweiterungsmethodensyntax");
            customersMale_02.ForEach(c=> Console.WriteLine(c));


            // Abfrage 2 
            // alle Personen ermitteln, deren gehalt kleiner 3000€ beträgt, die personen sollen, nach dem NAchnamen sortiert werden,
            // von der Ergebnismenge sollen die erste Personen übersprungen werden (nicht angezeigt werden) und die nächsten drei personen sollen ausgewählt werden

            var customersMale_03 = (from c in customers
                                   where c.Capital < 3000.0m
                                   orderby c.Lastname descending
                                   select c).Skip(1).Take(3).ToList<Customer>(); // erweiterungsmethode nur bei listen/generic
            foreach(Customer c in customersMale_03)
            {
                Console.WriteLine(c);
            }

            //  Abfrage 2 mit Erweiterungsmethodensyntax

            var customersMale_04 = customers.Where(c => c.Capital < 3000.0m).OrderBy(c => c.Lastname).Skip(1).Take(3).ToList<Customer>();

            foreach(Customer c in customersMale_04)
            {
                Console.WriteLine(c);
            }

            //  Projektion
            //  SQL:    select id, firstname, lastname from customers ...
            //  Prokection: nur die Felder ID, Firstname, Lastname
            var customersProjection = (from c in customers
                                       where c.Birthdate.Year == 2004
                                       // hier wird eine anonyme Klasse erzeugt, der Name der Klasse kennt nur der Kompilierer, deshalb muss var als typ verwendet werden,
                                       // die Klasse beinhaltet die Properties CustomerId und name
                                       select new { 
                                           customerId = c.Id,
                                           name = c.Lastname +"\t"+ c.Firstname, 
                                       });
            Console.WriteLine("\nProjektion- Abfragesyntax");
            foreach (var item in customersProjection)
            {
                Console.WriteLine(item.customerId + "->" + item.name);
            }

            Console.ReadKey();

        }


        // Testdaten für LINQ-Abfragen erzeugen
        private static List<Customer> CreateCustomers()
        {
            return new List<Customer>
            {
                new Customer(100,"Tobias", "Laser", new DateTime(2003, 1,30), 15000.0m,EGender.male),
                new Customer() {
                    Id=101, Firstname="Lucas", Gender=EGender.male, Lastname="Schebor", Capital=2204.90m, Birthdate= new DateTime(2004, 12,6)
                },
                new Customer(102, "Michael", "Zechner", new DateTime(2004, 2,14), 2002.22m, EGender.male),
                new Customer(103, "Dominik", "Vötter", new DateTime(2004, 12,14), 1002.22m, EGender.male),
                new Customer(104, "Karin", "Sowieso", new DateTime(1998, 5,21), 2223.22m, EGender.female),
                new Customer(105, "Sabine", "Gutkauf", new DateTime(2006, 3,3), 343.99m, EGender.female),
            };
        }
    }
}