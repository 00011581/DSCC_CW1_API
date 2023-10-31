using API.Data;
using API.Models.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public TopicRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ICollection<TopicDTO> GetAll()
        {
            var topics = _dbContext.Topics.ToList();
            return _mapper.Map<List<TopicDTO>>(topics);
        }
    }
}
