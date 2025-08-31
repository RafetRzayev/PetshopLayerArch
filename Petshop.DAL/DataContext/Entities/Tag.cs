namespace Petshop.DAL.DataContext.Entities;

public class Tag : TimeStample
{
    public string Name { get; set; } = null!;

    public ICollection<ProductTag> ProductTags {  get; set; } = [];
}