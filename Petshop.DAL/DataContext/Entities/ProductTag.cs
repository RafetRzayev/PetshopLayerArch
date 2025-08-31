namespace Petshop.DAL.DataContext.Entities;

public class ProductTag : Entity
{
    public int ProductId {  get; set; }

    public Product? Product { get; set; }

    public int TagId {  get; set; }

    public Tag? Tag { get; set; }
}