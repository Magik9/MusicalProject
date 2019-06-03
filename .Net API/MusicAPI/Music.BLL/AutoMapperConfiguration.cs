using AutoMapper;
using Music.DAL.TablesClasses;
using Music.BLL.DTO;

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
                    .ForMember(x => x.band, opt => opt.MapFrom(y => y.Disco.Band.Nome))
                    .ForMember(x => x.Band_Id, opt => opt.MapFrom(y => y.Disco.Band.Id))
                    .ReverseMap()
                    .ForMember(s => s.Disco, opt => opt.Ignore())
                    .ForPath(s => s.Disco.Band, opt => opt.Ignore());

                cfg.CreateMap<BranoDTO, DiscoDTO>()
                    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Disco_Id))
                    .ForMember(d => d.titolo, opt => opt.MapFrom(s => s.disco));

                cfg.CreateMap<BranoDTO, Disco>()
                    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Disco_Id))
                    .ForMember(d => d.Titolo, opt => opt.MapFrom(s => s.disco));

                cfg.CreateMap<BranoDTO, BandDTO>()
                    .ForMember(d => d.nome, opt => opt.MapFrom(s => s.band))
                    .ForMember(d => d.annoFondazione, opt => opt.MapFrom(s => s.anno));

                cfg.CreateMap<Disco, DiscoDTO>()
                    .ForMember(d => d.band, opt => opt.MapFrom(s => s.Band.Nome))
                    .ReverseMap()
                    .ForMember(s => s.Band, opt => opt.Ignore());

                cfg.CreateMap<DiscoDTO, BandDTO>()
                    .ForMember(d => d.nome, opt => opt.MapFrom(s => s.band))
                    .ForMember(d => d.annoFondazione, opt => opt.MapFrom(s => s.anno));

                cfg.CreateMap<Band, BandDTO>()
                    .ReverseMap();
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
