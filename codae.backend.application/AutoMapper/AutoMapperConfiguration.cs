using AutoMapper;

namespace codae.backend.application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings() =>
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToViewModelProfile());
                cfg.AddProfile(new ViewModelToModel());                
            });
    }
}
