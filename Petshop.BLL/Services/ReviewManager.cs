using AutoMapper;
using Petshop.BLL.Constants;
using Petshop.BLL.Services.Contracts;
using Petshop.BLL.ViewModels;
using Petshop.DAL.DataContext.Entities;
using Petshop.DAL.Repositories.Contracts;

namespace Petshop.BLL.Services;

public class ReviewManager : CrudManager<Review, ReviewViewModel, CreateReviewViewModel, UpdateReviewViewModel>, IReviewService
{
    private readonly FileService _fileService;
   
    public ReviewManager(IRepository<Review> respository, IMapper mapper, FileService fileService) : base(respository, mapper)
    {
        _fileService = fileService;
    }

    public override async Task CreateAsync(CreateReviewViewModel model)
    {
        if (model.ImageFile != null)
        {
            model.ImageName = await  _fileService.GenerateFile(model.ImageFile, FilePathConstants.ReviewImagePath);
        }

        await base.CreateAsync(model);
    }
}