using AutoMapper;
using POC.Domain.Commands;
using POC.Domain.Models;
using POC.Domain.ViewModel;

namespace POC.SERVICE.API.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile(){
            CreateMap<Client, ClientViewModel>();

            CreateMap<ClientViewModel, Client>();

            CreateMap<ClientViewModel, RegisterNewClientCommand>();

            CreateMap<ClientViewModel, UpdateClientCommand>();

        }
    }
}