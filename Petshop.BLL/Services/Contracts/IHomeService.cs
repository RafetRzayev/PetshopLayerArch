using Petshop.BLL.ViewModels;

namespace Petshop.BLL.Services.Contracts;

public interface IHomeService
{
    Task<HomeViewModel> GetHomeViewModel();
}
