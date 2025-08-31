namespace Petshop.BLL.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? AdditionalInformation { get; set; }

    public decimal Price { get; set; }

    public string? CoverImageName { get; set; }

    public string? CategoryName { get; set; }

    //public CategoryViewModel? Category { get; set; }

    public IList<string> ImageNames { get; set; } = [];
}

public class CreateProductViewModel
{
}

public class UpdateProductViewModel
{
}
