namespace Petshop.DAL.DataContext.Entities;

public class ProductImage : TimeStample
{
    public string ImageName { get; set; } = null!;

    public int ProductId {  get; set; }

    public Product? Product { get; set; }
}