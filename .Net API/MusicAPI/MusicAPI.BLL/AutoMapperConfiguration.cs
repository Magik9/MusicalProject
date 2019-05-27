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
                    .ForMember(x => x.band, opt => opt.MapFrom(y => y.Disco.Band.Nome));
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
