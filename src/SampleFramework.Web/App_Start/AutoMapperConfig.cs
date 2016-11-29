using AutoMapper;
using SampleFramework.Domain.Models;
using SampleFramework.Web.Models;

namespace SampleFramework.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterAutoMapper()
        {
            Mapper.CreateMap<MetaData, MetaDataViewModel>();
            Mapper.CreateMap<HomePage, HomePageViewModel>();
        }
    }
}