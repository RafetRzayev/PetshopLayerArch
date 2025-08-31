namespace Petshop.DAL.DataContext.Entities;

public class Review : TimeStample
{
    public float Rate {  get; set; }

    public string? ImageName {  get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Description { get; set; } = null!;

    public ReviewStatus ReviewStatus { get; set; }

    public int ProductId {  get; set; }

    public Product? Product { get; set; }

    public string? AppUserId {  get; set; }

    public AppUser? AppUser { get; set; }
}

public enum ReviewStatus
{
    Pending,
    Approve,
    Rejected
}
