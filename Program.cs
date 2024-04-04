namespace PizzaStore2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            store.Start();
            store.Menu();

            Console.ReadKey();
        }
    }
}
