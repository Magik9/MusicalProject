using AutoMapper;
using Music.DAL.TablesClasses;
using Music.BLL.DTO;
using Music.BLL.BO;

namespace Music.BLL
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Brano, BranoDTO>()
                    .ForMember(x => x.disco, opt => opt.MapFrom(y => y.Disco.Titolo))
                    .ForMember(x => x.anno, opt => opt.MapFrom(y => y.Disco.Anno))
                    .ForMember(x => x.band, opt => opt.MapFrom(y => y.Disco.Band.Nome));

                cfg.CreateMap<Disco, DiscoDTO>()
                    .ForMember(d => d.band, opt => opt.MapFrom(s => s.Band.Nome))
                    .ReverseMap()
                    .ForMember(s => s.Band, opt => opt.Ignore());

                cfg.CreateMap<BranoBO, Disco>()
                    .ForMember(d => d.Titolo, opt => opt.MapFrom(s => s.disco))
                    .ForPath(d => d.Band.Nome, opt => opt.MapFrom(s => s.band));

                cfg.CreateMap<DiscoBO, Disco>()
                    .ForMember(d => d.Titolo, opt => opt.MapFrom(s => s.titolo))
                    .ForMember(d => d.Anno, opt => opt.MapFrom(s => s.anno))
                    .ForPath(d => d.Band.Nome, opt => opt.MapFrom(s => s.band));

                /*cfg.CreateMap<BranoDTO, DiscoDTO>()
                    .ForMember(d => d.titolo, opt => opt.MapFrom(s => s.disco));*/

                /*cfg.CreateMap<BranoDTO, BandDTO>()
                    .ForMember(d => d.nome, opt => opt.MapFrom(s => s.band))
                    .ForMember(d => d.annoFondazione, opt => opt.MapFrom(s => s.anno));*/



                /*cfg.CreateMap<DiscoDTO, BandDTO>()
                    .ForMember(d => d.nome, opt => opt.MapFrom(s => s.band))
                    .ForMember(d => d.annoFondazione, opt => opt.MapFrom(s => s.anno));*/

                /*cfg.CreateMap<Band, BandDTO>()
                    .ReverseMap();*/
            });
        }
    }

    public class MyMappings : Profile
    {
        public override string ProfileName
        {
            get { return "MyMappings"; }
        }

    }
}
