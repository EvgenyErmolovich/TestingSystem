using TestingSystem.Domain.Entities;
using System.Collections.Generic;

namespace TestingSystem.Domain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        void Create(User entity);
        void Update(User entity);
        void Delete(User entity);
        User GetById(int id);
        User GetByLogin(string login);
        bool IsUserExists(string login);
    }
}
