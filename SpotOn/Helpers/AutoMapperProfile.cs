using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Accounts;
using WebApi.Models.Gallery;
using WebApi.Models.Artisan;
using WebApi.Models.LocalArea;
using WebApi.Models.UserState;
using WebApi.Models.Users;
using WebApi.Models.Bank;
using WebApi.Models.Dashboard;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        // mappings between model and entity objects
        public AutoMapperProfile()
        {
            CreateMap<Account, AccountResponse>();

            CreateMap<Account, AuthenticateResponse>();

            CreateMap<RegisterRequest, Account>();

            CreateMap<CreateRequest, Account>();

            CreateMap<PhotoUpdateRequest, Account>();

            CreateMap<UpdateRequest, Account>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));

            CreateMap<Gallery, GalleryResponse>();
            CreateMap<GalleryRequests, Gallery>();

            CreateMap<Artisan, ArtisanResponse>();
            CreateMap<ArtisanRequest, Artisan>();
            CreateMap<ArtisanTypeRequest, ArtisanType>();
            CreateMap<ArtisanType, ArtisanTypeResponse>();

            CreateMap<LocalArea, LocalAreaResponse>();
            CreateMap<LocalAreaRequest, LocalArea>();

            CreateMap<UserState, UserStateResponse>();
            CreateMap<UserStateRequest, UserState>();
            CreateMap<PhotoRequest, Artisan>();
            CreateMap<Artisan, ArtisanDisplayResponse>();
            CreateMap<ArtisanFilterRequest, Artisan>();

            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>();

            CreateMap<BankRequest, Bank>();
            CreateMap<Bank, BankResponse>();

            CreateMap<Artisan, DashboardResponse>();

        }
    }
}