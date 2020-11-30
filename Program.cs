using System;

namespace ConsoleApp1
{
    class program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            Basket basket = new Basket();
            int c = 1;
            while (c != 0)
            {
                Console.WriteLine("Choose an operation: ");
                Console.WriteLine("1. Show products.");
                Console.WriteLine("2. Add product.");
                Console.WriteLine("3. Find product.");
                Console.WriteLine("4. Add product to my basket.");
                Console.WriteLine("5. Show my basket.");
                Console.WriteLine("6. End.");
                int variable = Int32.Parse(Console.ReadLine());
                switch (variable)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("-------Products in the store-------");
                        Console.WriteLine();
                        showProducts(database);
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.Clear();
                        addProduct(database);
                        Console.WriteLine("Product succesfully added");
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Type a name of product that you want to find");
                        string name = Console.ReadLine();
                        findproduct(database, name);
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.Clear();
                        addBasket(database, basket);
                        Console.WriteLine("Product succesfully added to your basket");
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("-------Products in my basket-------");
                        Console.WriteLine();
                        showBasket(basket);
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    case 6:
                        c = 0;
                        break;
                }
            }
            Console.ReadKey();
        }

        static void addProduct(Database database)
        {
            Product product = new Product();
            Console.WriteLine("Type product's name: ");
            product.name = Console.ReadLine();
            Console.WriteLine("Type product's price: ");
            product.price = Int32.Parse(Console.ReadLine());
            database.products.Add(product); 
        }
        static void findproduct(Database database, string name)
        {
            int check = 0;
            foreach (Product item in database.products)
            {
                if (item.name == name)
                {
                    check = 1;
                    Console.WriteLine("Product's name: {0}", item.name);
                    Console.WriteLine("Product's price: {0}", item.price);
                }   
            }
            if (check == 0) Console.WriteLine("There is no such product");
        }
        static void showProducts(Database database)
        {
            int i = 0;
            foreach (Product item in database.products)
            {
                i++;
                Console.WriteLine("{0}. Product's name: {1}", i, item.name);
                Console.WriteLine("   Product's price: {0}",item.price);
            }
        }

        static void addBasket(Database database, Basket basket)
        {
            int check = 0;
            Product product = new Product();
            Console.WriteLine("Type a name of product, you want to add");
            string name = Console.ReadLine();
            foreach (Product item in database.products)
            {
                if (name == item.name)
                {
                    check = 1;
                    product.name = item.name;
                    product.price = item.price;
                    basket.products.Add(product);
                }
            }
            if (check == 0) Console.WriteLine("There is no such product");
        }

        static void showBasket(Basket basket)
        {
            int i = 0;
            foreach (Product item in basket.products)
            {
                i++;
                Console.WriteLine("{0}. Product's name: {1}", i, item.name);
                Console.WriteLine("   Product's price: {0}", item.price);
            }
        }
    }
}
