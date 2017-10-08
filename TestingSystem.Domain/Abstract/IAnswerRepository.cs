using TestingSystem.Domain.Entities;
using System.Collections.Generic;

namespace TestingSystem.Domain.Abstract
{
    public interface IAnswerRepository
    {
        IEnumerable<Answer> GetAll();
        void Create(Answer entity);
        void Update(Answer entity);
        void Delete(Answer entity);
        Answer GetById(int id);
    }
}
