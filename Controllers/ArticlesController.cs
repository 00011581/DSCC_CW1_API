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
        /// <summary>
        /// Returns a list of all existing articles
        /// </summary>
        /// <response code="200">Success</response>
        /// <returns>List of articles</returns>
        [HttpGet]
        public IEnumerable<ArticleDTO> Get()
        {
            return _articleRepository.GetAll();
        }

        // GET api/Articles/5
        /// <summary>
        /// Returns a specific article by Id
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="404">Article not found</response>
        /// <returns>List a single article</returns>
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
        /// <summary>
        /// Creates an article
        /// </summary>
        /// <response code="201">Article created successfully</response>
        /// <response code="400">Not existing TopicId</response>
        /// <response code="500">Internal Server Error</response>
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
        /// <summary>
        /// Updates an article by Id
        /// </summary>
        /// <response code="200">Article updated successfully</response>
        /// <response code="400">Not existing TopicId</response>
        /// <response code="404">Article not found</response>
        /// <response code="500">Internal Server Error</response>
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
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // DELETE api/Articles/5
        /// <summary>
        /// Deletes an article by Id
        /// </summary>
        /// <response code="204">Article deleted successfully</response>
        /// <response code="404">Article not found</response>
        /// <response code="500">Internal Server Error</response>
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
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
