using System;
using System.Collections.Generic;
using System.Linq;

// OCP: Software entities should be open for extension, but closed for modification.
// Bad example


public class ProductBad
{
    public string Name;
    public string Color;
    public string Size;

    public ProductBad(string name, string color, string size)
    {
        Name = name;
        Color = color;
        Size = size;
    }
}


public class ProductFilterBad
{
    public IEnumerable<ProductBad> FilterByColor(IEnumerable<ProductBad> products, string color)
    {
        foreach (var p in products)
        {
            if (p.Color == color)
                yield return p;
        }
    }

    public IEnumerable<ProductBad> FilterBySize(IEnumerable<ProductBad> products, string size)
    {
        foreach (var p in products)
            if (p.Size == size)
                yield return p;
    }

    // Adding new filter logic = modifying this class violates OCP

}


public class Product
{
    public string Name;
    public string Color;
    public string Size;

    public Product(string name, string color, string size)
    {
        Name = name;
        Color = color;
        Size = size;
    }
}

public interface ISpecification<T>
{
    bool IsSatisfied(T item);
}

public class ColorSpecification : ISpecification<Product>
{
    private string _color;
    public ColorSpecification(string color) => _color = color;
    public bool IsSatisfied(Product item) => item.Color == _color;
}

public class SizeSpecification : ISpecification<Product>
{
    private string _size;
    public SizeSpecification(string size) => _size = size;

    public bool IsSatisfied(Product item) => item.Size == _size;
}

public class ProductFilter
{
    public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
    {
        foreach (var item in items)
            if (spec.IsSatisfied(item))
                yield return item;
    }
}


public class Program
{
    public static void Main()
    {
        // Only GOOD example executed in main
        var apple = new Product("Apple", "Green", "Small");
        var tree = new Product("Tree", "Green", "Large");
        var house = new Product("House", "Blue", "Large");

        var products = new List<Product> { apple, tree, house };

        var filter = new ProductFilter();
        var greenSpec = new ColorSpecification("Green");

        var greenProducts = filter.Filter(products, greenSpec);

        Console.WriteLine("Filtered products (Green):");
        foreach (var p in greenProducts)
            Console.WriteLine($"- {p.Name}");
    }
}