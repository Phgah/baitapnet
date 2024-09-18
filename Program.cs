using System;
using System.Collections.Generic;

public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }

    public Product(string name, double price, string description, int quantity)
    {
        Name = name;
        Price = price;
        Description = description;
        Quantity = quantity;
    }

    public virtual void DisplayProductInfo()
    {
        Console.WriteLine($"Name: {Name}, Price: {Price:C}, Description: {Description}, Quantity: {Quantity}");
    }

    public Product CloneWithQuantity(int quantity)
    {
        return new Product(Name, Price, Description, quantity);
    }
}

public class Electronic : Product
{
    public int WarrantyMonths { get; set; }

    public Electronic(string name, double price, string description, int quantity, int warrantyMonths)
        : base(name, price, description, quantity)
    {
        WarrantyMonths = warrantyMonths;
    }

    public override void DisplayProductInfo()
    {
        base.DisplayProductInfo();
        Console.WriteLine($"Warranty: {WarrantyMonths} months");
    }

    public new Product CloneWithQuantity(int quantity)
    {
        return new Electronic(Name, Price, Description, quantity, WarrantyMonths);
    }
}

public class Clothing : Product
{
    public string Size { get; set; }
    public string Color { get; set; }

    public Clothing(string name, double price, string description, int quantity, string size, string color)
        : base(name, price, description, quantity)
    {
        Size = size;
        Color = color;
    }

    public override void DisplayProductInfo()
    {
        base.DisplayProductInfo();
        Console.WriteLine($"Size: {Size}, Color: {Color}");
    }

    public new Product CloneWithQuantity(int quantity)
    {
        return new Clothing(Name, Price, Description, quantity, Size, Color);
    }
}

public class Food : Product
{
    public DateTime ExpirationDate { get; set; }

    public Food(string name, double price, string description, int quantity, DateTime expirationDate)
        : base(name, price, description, quantity)
    {
        ExpirationDate = expirationDate;
    }

    public override void DisplayProductInfo()
    {
        base.DisplayProductInfo();
        Console.WriteLine($"Expiration Date: {ExpirationDate.ToShortDateString()}");
    }

    public new Product CloneWithQuantity(int quantity)
    {
        return new Food(Name, Price, Description, quantity, ExpirationDate);
    }
}

public class ShoppingCart
{
    public List<Product> Products { get; set; }

    public ShoppingCart()
    {
        Products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
        Console.WriteLine($"{product.Name} added to cart.");
    }

    public void RemoveProduct(Product product)
    {
        Products.Remove(product);
        Console.WriteLine($"{product.Name} removed from cart.");
    }

    public void DisplayCart()
    {
        if (Products.Count == 0)
        {
            Console.WriteLine("Your cart is empty.");
        }
        else
        {
            Console.WriteLine("Products in your cart:");
            foreach (var product in Products)
            {
                product.DisplayProductInfo();
            }
        }
    }

    public double CalculateTotalPrice()
    {
        double total = 0;
        foreach (var product in Products)
        {
            total += product.Price * product.Quantity;
        }
        return total;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tạo các sản phẩm mẫu cho từng lớp con
        Electronic asusLaptop = new Electronic("Asus Laptop", 600, "Asus gaming laptop", 1, 24);
        Electronic sonyHeadphones = new Electronic("Sony Headphones", 200, "Noise cancelling headphones", 1, 6);
        Electronic magicMouse = new Electronic("Magic mouse", 100, "wireless and rechargeable", 1, 6);

        Clothing nikeTshirt = new Clothing("Nike T-Shirt", 30, "Cotton T-shirt", 2, "L", "Black");
        Clothing adidasJacket = new Clothing("Adidas Jacket", 120, "Winter jacket", 1, "M", "Blue");
        Clothing sambaShoes = new Clothing("Samba Shoes", 110, "Cushioned midsole", 1, "39", "White");

        Food banana = new Food("Banana", 1.2, "Fresh bananas", 10, new DateTime(2024, 1, 15));
        Food milk = new Food("Milk", 2.5, "Organic milk", 5, new DateTime(2024, 2, 1));
        Food bread = new Food("Bread", 4.5, "Sour bread", 7, new DateTime(2024, 9, 20));

        // Tạo giỏ hàng
        ShoppingCart cart = new();

        // Danh sách sản phẩm có sẵn
        List<Product> availableProducts = new List<Product>
        {
            asusLaptop, sonyHeadphones, magicMouse, nikeTshirt, adidasJacket, sambaShoes, banana, milk, bread
        };

        bool continueShopping = true;

        while (continueShopping)
        {
            Console.WriteLine("\nAvailable products:");
            for (int i = 0; i < availableProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableProducts[i].Name} - {availableProducts[i].Price:C}");
            }

            // Nhập số sản phẩm
            int productIndex;
            Console.Write("Enter the number of the product to add to your cart (or 0 to checkout): ");
            string inputProductIndex = Console.ReadLine();

            if (!int.TryParse(inputProductIndex, out productIndex) || productIndex <= 0 || productIndex > availableProducts.Count)
            {
                Console.WriteLine("Invalid input. Please enter a valid product number.");
                continue;
            }

            productIndex--;  // Chuyển đổi từ 1-based index sang 0-based index

            // Nhập số lượng
            int quantity;
            Console.Write("Enter the quantity: ");
            string inputQuantity = Console.ReadLine();

            if (!int.TryParse(inputQuantity, out quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity. Please enter a positive number.");
                continue;
            }

            Product selectedProduct = availableProducts[productIndex].CloneWithQuantity(quantity);
            cart.AddProduct(selectedProduct);

            // Hiển thị giỏ hàng và tổng giá trị đơn hàng
            cart.DisplayCart();
            double total = cart.CalculateTotalPrice();
            Console.WriteLine($"\nTotal Price: {total:C}");
        }
    }
}
