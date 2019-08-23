using AutoMapper;

namespace Anabi.Tests.Common
{
    public static class MapperCreator
    {
        public static IMapper CreateAutomapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperMappings>();
            });
            //configuration.AssertConfigurationIsValid();

            return configuration.CreateMapper();
        }
    }
}
