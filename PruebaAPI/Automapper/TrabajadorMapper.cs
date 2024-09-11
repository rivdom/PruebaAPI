using AutoMapper;
using PruebaAPI.Models;
using PruebaAPI.Models.DTO;

namespace PruebaAPI.Automapper
{
    public class TrabajadorMapper : Profile
    {
        public TrabajadorMapper()
        {
            CreateMap<Trabajador, TrabajadorDTO>().ReverseMap();
            CreateMap<Trabajador, CrearTrabajadorDTO>().ReverseMap();
        }
    }
}
