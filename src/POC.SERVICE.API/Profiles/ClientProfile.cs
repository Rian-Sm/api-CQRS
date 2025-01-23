using AutoMapper;
using POC.Domain.Models;
using POC.Domain.ViewModel;

namespace POC.SERVICE.API.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile(){
            CreateMap<Client, ClientViewModel>();

            CreateMap<ClientViewModel, Client>();
        }
    }
}