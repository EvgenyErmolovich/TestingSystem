using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestingSystem.Domain.Entities;
using TestingSystem.Domain.Abstract;

namespace TestingSystem.Domain.Concrete
{
    public class EFQuestionRepository : IQuestionRepository
    {
        private readonly DbContext context;

        public EFQuestionRepository(DbContext context)
        {
            this.context = context;
        }

        public Question GetById(int id)
        {
            return context.Set<Question>().FirstOrDefault(q => q.Id == id);
        }

        public IEnumerable<Question> GetAll()
        {
            return context.Set<Question>();
        }

        public void Create(Question entity)
        {
            context.Set<Question>().Add(entity);
            context.SaveChanges();
        }

        public void Update(Question entity)
        {
            Question questionToUpdate = context.Set<Question>().FirstOrDefault(q => q.Id == entity.Id);
            context.Entry(questionToUpdate).CurrentValues.SetValues(entity);
            context.SaveChanges();
        }

        public void Delete(Question entity)
        {
            Question question = context.Set<Question>().FirstOrDefault(q => q.Id == entity.Id);
            context.Set<Question>().Remove(question);
            context.SaveChanges();
        }

    }
}
