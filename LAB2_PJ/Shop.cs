namespace LAB2_PJ
{
//PROGRAM - SHOP VALUES
    class Program
    {
        public static void Main()
        {
            Seller treacher = new Seller("Jan Kowalski", 50);

            Buyer buyer1 = new Buyer("Jaś Fasola 1", 25);
            Buyer buyer2 = new Buyer("Jaś Fasola 2", 21);
            Buyer buyer3 = new Buyer("Jaś Fasola 3", 23);

            buyer1.AddProduct(new Fruit("Apple", 6));
            buyer1.AddProduct(new Meat("Fish", 0.5));

            Person[] persons = { treacher, buyer1, buyer2, buyer3 };

            Product[] products = {
                new Fruit("Apple", 1000),
                new Fruit("Banana", 700),
                new Fruit("Orange", 500),
                new Meat("Fish", 100.0),
                new Meat("Beef", 75.0)
            };

            Shop shop = new Shop("Super Market", persons, products);

            shop.Print();
        }
    }

    interface IThing
    {
        string Name { get; }
    }

    class Shop
    {
        private string name;
        private Person[] people;
        private Product[] products;

        public string Name
        {
            get { return name; }
        }

        public Shop(string name, Person[] people, Product[] products)
        {
            this.name = name;
            this.people = people;
            this.products = products;
        }

        public void Print()
        {
            Console.WriteLine($"Shop: {this.name}");
            Console.WriteLine("-- People: --");
            foreach (var p in people)
            {
                p.Print("\t");
            }
            Console.WriteLine("-- Products: --");
            foreach (var p in products)
            {
                p.Print("\t");
            }

        }
    }
}