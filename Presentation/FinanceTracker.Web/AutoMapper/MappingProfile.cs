using AutoMapper;
using ExpenseTracker.UserOperations.DataTransferObjects;
using FinanceTracker.Business.DataTransferObjects.Coin;
using FinanceTracker.Business.DataTransferObjects.Stock;
using FinanceTracker.Data.Entities.CoinEntities;
using FinanceTracker.Data.Entities.StockEntities;
using FinanceTracker.Web.Models.ViewModels.Authentication;
using FinanceTracker.Web.Models.ViewModels.Coin;
using FinanceTracker.Web.Models.ViewModels.Stock;

namespace FinanceTracker.Web.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SignUpViewModel, UserDto>();
            CreateMap<UserDto, SignUpViewModel>();
			CreateMap<LoginViewModel, UserDto>();
			CreateMap<UserDto, LoginViewModel>();

			CreateMap<StockAddViewModel, StockDto>();
			CreateMap<StockDto, StockAddViewModel>();

			CreateMap<StockAddViewModel, Stock>();
			CreateMap<Stock, StockAddViewModel>();

			CreateMap<StockAddViewModel, StockAssetDto>();
			CreateMap<StockAssetDto, StockAddViewModel>();

			CreateMap<StockAsset, StockAssetDto>();
			CreateMap<StockAssetDto, StockAsset>();


            CreateMap<CoinAddViewModel, CoinAssetDto>();
            CreateMap<CoinAssetDto, CoinAddViewModel>();

            CreateMap<CoinAsset, CoinAssetDto>();
            CreateMap<CoinAssetDto, CoinAsset>();
        }
    }
}
