using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore2
{
    public class UserDialog
    {
        MenuCatalog _menuCatalog;

        public UserDialog(MenuCatalog menuCatalog)
        {
            _menuCatalog = menuCatalog;
        }

        Pizza AddNewPizza()
        {
            Pizza pizzaItem = new Pizza();

            Console.Clear();

            Console.Write("Enter pizza name: ");
            pizzaItem.Name = Console.ReadLine();

            string input = "";
            Console.Write("Enter price: ");
            try
            {
                input = Console.ReadLine();
                pizzaItem.Price = Int32.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Price '{input}' isn't valid, please try again.");
                throw;
            }

            input = "";
            Console.Write("Enter pizza ID: ");
            try
            {
                input = Console.ReadLine();
                pizzaItem.ID = Int32.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine($"ID '{input}' isn't valid, please try again.");
                throw;
            }

            return pizzaItem;
        }
        public void DeletePizza()
        {
            Console.Clear();      
         
            Console.Write("Enter pizza ID to delete: ");
            string input = Console.ReadLine();

            int pizzaID;

            if (!int.TryParse(input, out pizzaID))
            {
                Console.WriteLine($"Invalid Input '{input}', please enter a valid pizza ID or check the menu.");
                return;
            }

            Pizza existingPizza = _menuCatalog.Read(pizzaID);
            if (existingPizza == null)
            {
                Console.WriteLine($"No pizza with ID {pizzaID} found, please try another.");
                return;
            }

            _menuCatalog.Delete(pizzaID);
            Console.WriteLine($"Pizza with ID {pizzaID} is deleted");

        }
        public void UpdatePizza()
        {
            Console.Clear();

            Console.Write("Enter pizza ID to update: ");
            string input = Console.ReadLine();

            int pizzaID;

            if (!int.TryParse(input, out pizzaID))
            {
                Console.WriteLine($"Invalid ID '{input}', please enter a valid pizza ID or check the menu.");
                return;
            }

            Pizza existingPizza = _menuCatalog.Read(pizzaID);

            if (existingPizza == null)
            {
                Console.WriteLine($"No pizza with ID {pizzaID} was found, please try another.");
                return;
            }


            Pizza updatedPizza = AddNewPizza();
            _menuCatalog.Update(updatedPizza, updatedPizza.ID);

            Console.WriteLine($"Pizza with ID {pizzaID} is updated: {updatedPizza}");
        }
        public void SearchPizza()
        {
            Console.Clear();

            Console.Write("Enter pizza Name to search: ");
            string pizzaName = Console.ReadLine();            

            Pizza existingPizza = _menuCatalog.Search(pizzaName);

            if (existingPizza == null)
            {
                Console.WriteLine($"No pizza with ID {pizzaName} was found, please try another.it");
                return;
            }

            Console.WriteLine($"Pizza with name {pizzaName} is found.\nIt costs: {existingPizza.Price}\nIt has ID: {existingPizza.ID}");
        }
        int MainMenuChoice(List<string> menuItems)
        {
            Console.Clear();
            
            foreach (string choice in menuItems)
            {
                Console.WriteLine(choice);
            }

            Console.Write("Enter option#: ");
           
            string input = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();

            try
            {
                int result = Int32.Parse(input);
                return result;
            }

            catch (FormatException)
            {
                Console.WriteLine($"'{input}' is not a valid choice, please pick a number from the menu.");
            }
            return -1;
        }
        public void Menu()
        {
            bool proceed = true;
            List<string> mainMenulist = new List<string>()
            {
                "0. Add Pizza",
                "1. Delete Pizza",
                "2. Update Pizza",
                "3. Search Pizza",
                "4. Display Menu",
                "5. Exit"
            };

            while (proceed)
            {
                int MenuChoice = MainMenuChoice(mainMenulist);
                Console.WriteLine();
                switch (MenuChoice)
                {
                    case 0:
                        try
                        {
                            Pizza pizza = AddNewPizza();
                            _menuCatalog.Create(pizza);
                            Console.WriteLine($"You created: {pizza}");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"No pizza created");
                        }
                        Console.WriteLine("Hit any key to continue");
                        Console.ReadKey();
                        break;
                    case 1:
                        try
                        {
                            DeletePizza();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Unable to delete pizza");
                        }
                        Console.Write("Hit any key to continue");

                        Console.ReadKey();
                        break;
                    case 2:
                        try
                        {
                            UpdatePizza();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Unable to update pizza");
                        }
                        Console.Write("Hit any key to continue");

                        Console.ReadKey();
                        break;
                    case 3:
                        try
                        {
                            SearchPizza();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Unable to find pizza");
                        }
                        Console.Write("Hit any key to continue");

                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        _menuCatalog.PrintMenu();
                        Console.WriteLine("Hit any key to continue");
                        Console.ReadKey();
                        break;
                    case 5:
                        proceed = false;
                        Console.WriteLine("Quitting Menu - Press button to exit");
                        break;
                    default:
                        Console.WriteLine("Not a valid choice, please pick a number from the menu.");
                        Console.WriteLine("Hit any key to continue");
                        Console.ReadKey();
                        break;
                }
            }

        }
    }
}
