using API.Models.DTOs;

namespace API.Repositories
{
    public interface IArticleRepository
    {
        ICollection<ArticleDTO> GetAll();
        ArticleDTO GetOne(int Id);
        void Create(ArticleCreateDTO articleCreateDTO);
        void Update(ArticleCreateDTO articleUpdateDTO, int Id);
        void Delete(int Id);
    }
}
