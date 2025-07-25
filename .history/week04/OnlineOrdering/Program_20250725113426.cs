using System;
using System.Collections.Generic;

// Address Class
public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public bool IsUSA()
    {
        return _country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
    }
}

// Customer Class
public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }

    public bool IsInUSA()
    {
        return _address.IsUSA();
    }
}

// Product Class
public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }
}

// Order Class
public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double totalProductCost = 0;
        foreach (Product product in _products)
        {
            totalProductCost += product.GetTotalCost();
        }

        double shippingCost = _customer.IsInUSA() ? 5.00 : 35.00;

        return totalProductCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "Shipping Label:\n";
        label += $"{_customer.GetName()}\n";
        label += _customer.GetAddress().GetFullAddress();
        return label;
    }
}

// Program Class to demonstrate functionality
public class Program
{
    public static void Main(string[] args)
    {
        // --- Order 1: Customer in USA ---
        Console.WriteLine("--- Order 1: Customer in USA ---");

        // Create Address for customer 1
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");

        // Create Customer 1
        Customer customer1 = new Customer("Alice Smith", address1);

        // Create Products for Order 1
        Product product1_1 = new Product("Laptop", "PROD001", 1200.00, 1);
        Product product1_2 = new Product("Mouse", "PROD002", 25.00, 2);
        Product product1_3 = new Product("Keyboard", "PROD003", 75.00, 1);

        // Create Order 1
        Order order1 = new Order(customer1);
        order1.AddProduct(product1_1);
        order1.AddProduct(product1_2);
        order1.AddProduct(product1_3);

        // Display results for Order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("\n" + order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Cost: ${order1.GetTotalCost():F2}");

        Console.WriteLine("\n" + new string('-', 40) + "\n"); // Separator

        // --- Order 2: Customer outside USA ---
        Console.WriteLine("--- Order 2: Customer outside USA ---");

        // Create Address for customer 2
        Address address2 = new Address("45 Wall St", "London", "Greater London", "UK");

        // Create Customer 2
        Customer customer2 = new Customer("Bob Johnson", address2);

        // Create Products for Order 2
        Product product2_1 = new Product("Smartphone", "PROD004", 800.00, 1);
        Product product2_2 = new Product("Headphones", "PROD005", 150.00, 1);

        // Create Order 2
        Order order2 = new Order(customer2);
        order2.AddProduct(product2_1);
        order2.AddProduct(product2_2);

        // Display results for Order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("\n" + order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Cost: ${order2.GetTotalCost():F2}");
    }
}