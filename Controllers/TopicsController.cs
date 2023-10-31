using API.Models.DTOs;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicRepository _topicRepository;

        public TopicsController(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        // GET: api/Topics
        [HttpGet]
        public IEnumerable<TopicDTO> Get()
        {
            return _topicRepository.GetAll();
        }
    }
}
