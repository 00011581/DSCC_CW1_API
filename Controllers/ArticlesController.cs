using API.Exceptions;
using API.Models.DTOs;
using API.Repositories;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;

        public ArticlesController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        // GET: api/Articles
        [HttpGet]
        public IEnumerable<ArticleDTO> Get()
        {
            return _articleRepository.GetAll();
        }

        // GET api/Articles/5
        [HttpGet("{id}")]
        public ActionResult<ArticleDTO> Get(int id)
        {
            try
            {
                return _articleRepository.GetOne(id);
            }
            catch (ArticleNotFoundException)
            {
                return NotFound("Not Found");
            }
        }

        // POST api/Articles
        [HttpPost]
        public ActionResult Post([FromBody] ArticleCreateDTO articleCreateDTO)
        {
            try
            {
                _articleRepository.Create(articleCreateDTO);
                return StatusCode(201, "Data created successfully");
            }
            catch (TopicNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // PUT api/Articles/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ArticleCreateDTO articleUpdateDTO)
        {
            try
            {
                _articleRepository.Update(articleUpdateDTO, id);
                return Ok("Data updated successfully");
            }
            catch (TopicNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArticleNotFoundException)
            {
                return NotFound("Not Found");
            }
        }

        // DELETE api/Articles/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _articleRepository.Delete(id);
                return StatusCode(204, "Data created successfully");
            }
            catch (ArticleNotFoundException)
            {
                return NotFound("Not Found");
            }
        }
    }
}
