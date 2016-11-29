namespace SampleFramework.Services.Interfaces
{
    public interface IMapModelService
    {
        TDest Map<TSrc, TDest>(TSrc source) where TDest : class;

        TDest Map<TDest>(object source) where TDest : class;
    }
}
