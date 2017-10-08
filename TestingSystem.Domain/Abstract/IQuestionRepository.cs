using TestingSystem.Domain.Entities;
using System.Collections.Generic;

namespace TestingSystem.Domain.Abstract
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetAll();
        void Create(Question entity);
        void Update(Question entity);
        void Delete(Question entity);
        Question GetById(int id);
    }
}
