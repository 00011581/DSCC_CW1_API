using API.Data;
using API.Exceptions;
using API.Models.DTOs;
using API.Models.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ArticleRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Create(ArticleCreateDTO articleCreateDTO)
        {
            if (!CheckIfTopicIdExists(articleCreateDTO.TopicId))
            {
                throw new TopicNotFoundException("Inputed topicId doesn't exist");
            }

            try
            {
                var articleEntity = _mapper.Map<Article>(articleCreateDTO);
                _dbContext.Articles.Add(articleEntity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void Delete(int Id)
        {
            var articleEntity = _dbContext.Articles.FirstOrDefault(article => article.Id == Id);
            if (articleEntity != null)
            {
                _dbContext.Articles.Remove(articleEntity); 
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArticleNotFoundException("Not Found");
            }
        }

        public ICollection<ArticleDTO> GetAll()
        {
            var articles = _dbContext.Articles.Include(article => article.Topic).ToList();
            return _mapper.Map<List<ArticleDTO>>(articles);
        }
        
        public ArticleDTO GetOne(int Id)
        {
            var articleEntity = _dbContext.Articles.Include(article => article.Topic).FirstOrDefault(article => article.Id == Id);
            if (articleEntity != null)
            {
                return _mapper.Map<ArticleDTO>(articleEntity);   
            }
            throw new ArticleNotFoundException("Not Found");
        }

        public void Update(ArticleCreateDTO articleUpdateDTO, int Id)
        {
            if (!CheckIfTopicIdExists(articleUpdateDTO.TopicId))
            {
                throw new TopicNotFoundException("Inputed topicId doesn't exist");
            }

            var articleEntity = _dbContext.Articles.FirstOrDefault(article => article.Id == Id);
            if (articleEntity != null)
            {
                _mapper.Map(articleUpdateDTO, articleEntity);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArticleNotFoundException("Not Found");
            }
        }

        private bool CheckIfTopicIdExists(int topicId)
        {
            var topic = _dbContext.Topics.FirstOrDefault(t => t.Id == topicId);
            if (topic == null)
            {
                return false;
            }
            return true;
        }
    }
}
