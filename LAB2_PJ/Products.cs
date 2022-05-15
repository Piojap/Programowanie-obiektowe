namespace LAB2_PJ
{
    abstract class Product : IThing
    {
        public Product(string name)
        {
            this.name = name;

        }

        protected string name;

        public string Name
        {
            get { return name; }
        }

        public abstract void Print(string prefix);
    }

    class Fruit : Product
    {
        int count;

        public int Count
        {
            get {return count;}
        }

        public Fruit(string name, int count) : base(name)
        {
            this.count = count;
        }

        public override void Print(string prefix)
        {
            Console.WriteLine($"{prefix}{this.name} ({this.count} fruits)");
        }
    }

    class Meat : Product

    {
        double weigth;

        public double Weigth
        {
            get {return weigth;}
        }

        public Meat(string name, double weigth) : base(name)
        {
            this.weigth = weigth;
        }

        public override void Print(string prefix)
        {
            Console.WriteLine(prefix + this.name + " (" + this.weigth + " kg)");
            Console.WriteLine($"{prefix}{this.name} ({this.weigth} kg)");
        }
    }
}
