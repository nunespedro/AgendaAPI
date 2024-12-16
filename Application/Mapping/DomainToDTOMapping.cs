using AgendaAPI.Domain.DTOs;
using AgendaAPI.Domain.Model;
using AutoMapper;

namespace AgendaAPI.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping() 
        { 
            CreateMap<Contact, ContactDTO>();
        }
    }
}
