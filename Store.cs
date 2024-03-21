using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore2
{
    public class Store
    {
        public void Start()
        {
            MenuCatalog _menuCatalog = new MenuCatalog();

            Pizza p1 = new Pizza()
            {Name = "Calzone", Price = 65, ID = 1};
            _menuCatalog.Create(new Pizza());
        }
               
    }
}
