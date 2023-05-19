namespace Task1
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        //the Equals method compares object references by default,
        // it will return true only if the two objects being compared are the exact same object instance
        public override bool Equals(object product)
        {
            if (product == null || !(product is Product))
            {
                return false;
            }

            var productToCompare = (Product)product;
            return this.Name == productToCompare.Name
                && this.Price == productToCompare.Price;
        }
    }
}
