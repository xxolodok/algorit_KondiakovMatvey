public class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ContactPhone { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class ProductMovement
{
    public int ProductId { get; set; }
    public int SupplierId { get; set; }
    public string Prefix { get; set; }
    public DateTime Date { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
class Program
{
    static void Main()
    {

        var productStocks = movements
    .GroupBy(m => m.ProductId)
    .Select(g => new
    {
        ProductId = g.Key,
        ProductName = products.FirstOrDefault(p => p.Id == g.Key)?.Name ?? "Неизвестно",
        Stock = g.Where(m => m.Prefix == "Поступление").Sum(m => m.Quantity)
              - g.Where(m => m.Prefix == "Продажа").Sum(m => m.Quantity)
    }).ToList();


        var productsBySuppliers = movements
            .Where(m => m.Prefix == "Поступление")
            .GroupBy(m => m.SupplierId)
            .Select(g => new
            {
                SupplierId = g.Key,
                SupplierName = suppliers.FirstOrDefault(s => s.Id == g.Key)?.Name ?? "Неизвестно",
                Products = g.GroupBy(m => m.ProductId)
                            .Select(pg => new
                            {
                                ProductId = pg.Key,
                                ProductName = products.FirstOrDefault(p => p.Id == pg.Key)?.Name ?? "Неизвестно",
                                TotalQuantity = pg.Sum(x => x.Quantity)
                            }).ToList()
            }).ToList();


        var salesByDate = movements
            .Where(m => m.Prefix == "Продажа")
            .GroupBy(m => m.Date.Date)
            .Select(g => new
            {
                SaleDate = g.Key,
                Products = g.GroupBy(m => m.ProductId)
                            .Select(pg => new
                            {
                                ProductId = pg.Key,
                                ProductName = products.FirstOrDefault(p => p.Id == pg.Key)?.Name ?? "Неизвестно",
                                TotalQuantity = pg.Sum(x => x.Quantity),
                                TotalAmount = pg.Sum(x => x.Quantity * x.UnitPrice)
                            }).ToList()
            }).ToList();

    }
}