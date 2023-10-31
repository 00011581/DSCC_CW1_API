using API.Models.DTOs;

namespace API.Repositories
{
    public interface ITopicRepository
    {
        public ICollection<TopicDTO> GetAll();
    }
}
