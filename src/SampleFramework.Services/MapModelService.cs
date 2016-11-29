using SampleFramework.Services.Interfaces;

namespace SampleFramework.Services
{
    public class MapModelService : IMapModelService
    {
        public TDest Map<TSrc, TDest>(TSrc source) where TDest : class
        {
            return AutoMapper.Mapper.Map<TSrc, TDest>(source);
        }

        public TDest Map<TDest>(object source) where TDest : class
        {
            return AutoMapper.Mapper.Map<TDest>(source);
        }
    }
}
