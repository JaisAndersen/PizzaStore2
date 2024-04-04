using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore2
{
    public class Store
    {   
        MenuCatalog menuCatalog;

        public Store()
        {
            menuCatalog = new MenuCatalog();
        }
        public void Start()
        {
            Pizza pizza1 = new Pizza()
            { Name = "Calzone", Price = 65, ID = 1 };
            menuCatalog.Create(pizza1);

            Pizza pizza2 = new Pizza()
            { Name = "Magherita", Price = 55, ID = 2 };
            menuCatalog.Create(pizza2);

            Pizza pizza3 = new Pizza()
            { Name = "Vesuvio", Price = 75, ID = 3 };
            menuCatalog.Create(pizza3);

            menuCatalog.PrintMenu();

            //Console.WriteLine();
            //int pizzaToBeFound = 1;
            //Console.WriteLine($"Finding Pizza {pizzaToBeFound}");
            //Pizza foundPizza = menuCatalog.Read(pizzaToBeFound);
            //Console.WriteLine(foundPizza);

            //Console.WriteLine();
            //string search = "Vesuvio";
            //Console.WriteLine($"Finding Pizza starting with: {search}");
            //foundPizza = menuCatalog.Search(search);
            //Console.WriteLine(foundPizza);

            //Console.WriteLine();
            //Console.WriteLine($"Updating Pizza #{foundPizza.Name}");
            //foundPizza.Name += " (Updated)";
            //menuCatalog.Update(foundPizza, foundPizza.ID);

            //    Console.WriteLine();
            //    menuCatalog.PrintMenu();

            //    Console.WriteLine();
            //    int pizzaToBeDeleted = 2;
            //    Console.WriteLine($"Deleting pizza#: {pizzaToBeDeleted}");
            //    menuCatalog.Delete(pizzaToBeDeleted);
            //    Console.WriteLine();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void Menu()
        {
            new UserDialog(menuCatalog).Menu();
        }

    }
}
