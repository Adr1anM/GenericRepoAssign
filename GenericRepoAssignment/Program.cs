// See https://aka.ms/new-console-template for more information
using GenericRepoAssignment;



Sculpture sculpture1 = new Sculpture { Id = 1, Author = "Igor Vieru", finishTime = DateTime.Parse("2024-03-16"), Material = "Stone", Name = "Renesance", Price = 20000, SculptureCount = 3, Weight = 400 };

Paint paint1 = new Paint { Id = 1, Author = "George Castor", Description = "This are the best paints", PaintsCount = 40, Price = 320 };

Paint paint2 = new Paint { Id = 2, Author = "Picasso", Description = "Barok style", PaintsCount = 20, Price = 600 };

Paint paint3 = new Paint { Id = 3, Author = "Filip Wong", Description = "Science fiction paints", PaintsCount = 40, Price = 530 };

IRepository<Paint> paints = new ListRepository<Paint>();

paints.Add(paint1);
paints.Add(paint2);
paints.Add(paint3);

IRepository<Sculpture> sculptures = new ListRepository<Sculpture>();
sculptures.Add(sculpture1);

IRepository<Order> orders = new ListRepository<Order>();   


MarketPlace market = new MarketPlace(paints, sculptures, orders);

IList<Product> productList =  market.GetAllProducts();
Console.WriteLine("Number of products: {0}",market.GetTotalProductCount());
string type;
foreach (Product product in productList)
{
    type = product.GetType().Name.ToString();
    Console.WriteLine($"Products Id: {product.Id} ProductType: {type}");
}

try 
{
    market.Purchase(sculpture1, 2, "Alan Noris");
}
catch(ArgumentNullException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch(ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

try
{
    market.Purchase(paint1, 3, "John Weak");
}
catch(ArgumentNullException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

DisplayPaintdata(paint3);
DisplayScuptureData(sculpture1);

IList<Order> allOrders = orders.GetAll();

PrintOrders(allOrders);

static void DisplayPaintdata(Paint paint)
{
    Console.WriteLine($"\nPaint Id: {paint.Id} " +
                      $"\nPaint's author: {paint.Author}" +
                      $"\nPaints count: {paint.PaintsCount}" +
                      $"\nPaint's price: {paint.Price}");
}
static void DisplayScuptureData(Sculpture scupture)
{
    Console.WriteLine($"\nSculpture Id: {scupture.Id} " +
                      $"\nSculpture's author: {scupture.Author}" +
                      $"\nSculpture count: {scupture.SculptureCount}" +
                      $"\nSculpture's price: {scupture.Price}");
}


static void PrintOrders(IList<Order> allOrders)
{
    if(allOrders.Count > 0)
    {
        foreach (Order order in allOrders)
        {
            Console.WriteLine($"\nOrder Id: {order.Id}" +
                              $"\nProduct Id: {order.ProductId}" +
                              $"\nOdrer quantity: {order.Quantity}" +
                              $"\nOrder Date: {order.OrderDate}" +
                              $"\nCustomer Name: {order.CustomerName}");
        }
    }
    else
    {
        Console.WriteLine("There are no orders");
    }
    
}