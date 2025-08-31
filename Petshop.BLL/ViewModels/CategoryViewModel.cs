namespace Petshop.BLL.ViewModels;

public class CategoryViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsDeleted { get; set; }
}

public class CreateCategoryViewModel
{
    public string Name { get; set; } = null!;
}

public class UpdateCategoryViewModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; }
}
