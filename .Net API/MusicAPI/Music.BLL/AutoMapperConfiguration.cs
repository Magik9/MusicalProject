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

                cfg.CreateMap<BranoBO, Brano>()
                    .ForMember(x => x.Disco, opt => opt.Ignore());

                cfg.CreateMap<Disco, DiscoDTO>()
                    .ForMember(d => d.band, opt => opt.MapFrom(s => s.Band.Nome))
                    .ForMember(d => d.image, opt => opt.MapFrom(s => s.Image));


                cfg.CreateMap<BranoBO, Disco>()
                    .ForMember(d => d.Titolo, opt => opt.MapFrom(s => s.disco))
                    .ForPath(d => d.Band.Nome, opt => opt.MapFrom(s => s.band));

                cfg.CreateMap<DiscoBO, Disco>()
                    .ForMember(d => d.Titolo, opt => opt.MapFrom(s => s.titolo))
                    .ForMember(d => d.Anno, opt => opt.MapFrom(s => s.anno))
                    .ForMember(d => d.Image, opt => opt.MapFrom(s => s.img))
                    .ForPath(d => d.Band.Nome, opt => opt.MapFrom(s => s.band));

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
