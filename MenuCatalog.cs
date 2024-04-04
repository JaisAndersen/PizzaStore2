using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore2
{
    public class MenuCatalog
    {
        List<Pizza> _pizzas;

        public MenuCatalog() 
        { 
            _pizzas = new List<Pizza>();
        }

        public void Create(Pizza pizza)
        {
            _pizzas.Add(pizza);           
        }        

        public void PrintMenu()        
        {
            foreach (Pizza pizza in _pizzas) 
            Console.WriteLine(pizza);
        }

        public Pizza Read(int number)
        {
            foreach (Pizza pizza in _pizzas)
            {
                if (pizza.ID == number)
                {
                    return pizza;
                }
            }
            return null;
        }

        public Pizza Search(string search)
        {
            foreach (Pizza pizza in _pizzas)
            {
                if (pizza.Name == search)
                return pizza;
            }
            return null;
        }

        public void Update(Pizza updatedPizza, int ID)
        {
            foreach (Pizza pizza in _pizzas)
            {
                if (pizza.ID == ID)
                {                   
                    pizza.Name = updatedPizza.Name;
                    pizza.Price = updatedPizza.Price;
                }                       
                return;
            }
        }

        public void Delete(int ID)
        {
            _pizzas.RemoveAll(Pizza => Pizza.ID == ID);
        }

    }
}
