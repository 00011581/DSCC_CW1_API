using API.Models.DTOs;
using API.Models.Entities;
using AutoMapper;

namespace API.Infrastructure
{
    public class GenericMapperProfile : Profile
    {
        public GenericMapperProfile()
        {
            CreateMap<Article, ArticleDTO>().ReverseMap();
            CreateMap<Article, ArticleCreateDTO>().ReverseMap();
            CreateMap<Topic, TopicDTO>().ReverseMap();
        }
    }
}
