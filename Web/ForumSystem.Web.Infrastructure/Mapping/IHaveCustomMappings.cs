using AutoMapper;

namespace ForumSystem.Web.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfiguration configuration);
    }
}
