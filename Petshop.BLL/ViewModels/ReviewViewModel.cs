//using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.AspNetCore.Http;
using Petshop.DAL.DataContext.Entities;

namespace Petshop.BLL.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public float Rate { get; set; }
        public string? ImageName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? AppUserId { get; set; }
        public string? AppUserName { get; set; }
        public string? AppUserProfileImageName { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateReviewViewModel
    {
        public float Rate { get; set; }
        public string? ImageName { get; set; }
        public IFormFile? ImageFile { get; set; }
        public ReviewStatus ReviewStatus { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public int ProductId { get; set; }
        public string? AppUserId { get; set; }
    }

    public class UpdateReviewViewModel
    {
        public int Id { get; set; }
        public float Rate { get; set; }
        public string? ImageName { get; set; }
        public IFormFile? ImageFile { get; set; }
        public ReviewStatus ReviewStatus { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public int ProductId { get; set; }
        public string? AppUserId { get; set; }
    }
}