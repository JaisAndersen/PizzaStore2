using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore2
{
    public class MenuCatalog
    {
        //List: private List<Pizza> _pizzas = new List<Pizza>();
        private Dictionary<int, Pizza> _pizzas = new Dictionary<int, Pizza>();

        public void Create(Pizza pizza)
        {
            //List: _pizzas.add(pizza);
            _pizzas.Add(pizza.ID, pizza);
        }

        public void PrintMenu()
        {
            foreach (Pizza p in _pizzas.Values) 
            Console.WriteLine(p);
        }
    }
}
