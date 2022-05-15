namespace LAB2_PJ
{
    abstract class Person : IThing
    {
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        protected string name;
        protected int age;

        public string Name
        {
            get { return name; }
        }

        public int Age
        {
            get { return age; }
        }

        public bool Equals(Person obj)
        {
            return obj.name == this.name && obj.age == this.age;
        }

        public abstract void Print(string prefix);
    }

    class Buyer : Person
    {
        protected List<Product> products = new List<Product>();

        public Buyer(string name, int age) : base(name, age){}

        public void AddProduct(Product product)
        {
            this.products.Add(product);
        }

        public void RemoveProduct(int index)
        {
            this.products.RemoveAt(index);
        }


        public override void Print(string prefix)
        {
            Console.WriteLine($"{prefix}Buyer: {this.name} ({this.age.ToString()} y.o)");

            if (products.Count > 0)
            {
                Console.WriteLine($"{prefix}\t -- Products: --");

                foreach (var p in products)
                {
                    p.Print($"{prefix}\t");
                }
            }
        }
    }

    class Seller : Person
    {
        public Seller(string name, int age) : base(name, age){}

        public override void Print(string prefix)
        {
            Console.WriteLine($"{prefix}Seller: {this.name} ({this.age.ToString()} y.o)");
        }
    }
}
