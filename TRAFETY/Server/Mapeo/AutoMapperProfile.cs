using AutoMapper;
using NetTopologySuite.Geometries;
using TRAFETY.Bd.Entity.Personas;
using TRAFETY.Bd.Entity.TTipo;
using TRAFETY.Shared.DTO.Personas;
using TRAFETY.Shared.DTO.TTipo;
using TRAFETY.Shared.DTO.Usuario;

namespace TRAFETY.Server.Mapeo
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(GeometryFactory geometryFactory)
        {
            #region ENTIDADES

            #region CONTEXTO
            #endregion

            #region EMPRESAS
            #endregion

            #region PERSONAS
            CreateMap<Persona, UserPersonaRegistrarDTO>();
            CreateMap<PersonaDTO, Persona>();
            CreateMap<Persona, PersonaDTO>();
            #endregion

            #region SALIDAS
            #endregion

            #region TTIPO
            CreateMap<TContactoDTO, TContacto>();
            CreateMap<TContacto, TContactoDTO>();
            CreateMap<TEmpresaDTO, TEmpresa>();
            CreateMap<TEmpresa, TEmpresaDTO>();
            CreateMap<TGuiaDTO, TGuia>();
            CreateMap<TGuia, TGuiaDTO>();
            CreateMap<TOrganizacionDTO, TOrganizacion>();
            CreateMap<TOrganizacion, TOrganizacionDTO>();
            CreateMap<TStaffDTO, TStaff>();
            CreateMap<TStaff, TStaffDTO>();
            #endregion

            #region USUARIO
            CreateMap<UserRegistrarDTO, Persona>();
            #endregion

            #endregion

            // ERROR SERGIO: falta mapeo de GUIAS

            // ERROR SERGIO: falta mapeo de los POINT
            //Ejemplo Point
            //CreateMap<ItemDoc, ItemDocDTO>()
            //    .ForMember(x => x.Latitud, x => x.MapFrom(y => y.UbicacionDoc.Y))
            //    .ForMember(x => x.Longitud, x => x.MapFrom(y => y.UbicacionDoc.X));

            //CreateMap<ItemDocDTO, ItemDoc>()
            //    .ForMember(x => x.UbicacionDoc, x => x.MapFrom(y =>
            //    geometryFactory.CreatePoint(new Coordinate(y.Longitud, y.Latitud))));
        }
    }
}
