using TestingSystem.Domain.Entities;
using System.Collections.Generic;

namespace TestingSystem.Domain.Abstract
{
    public interface IRoleRepository 
    {
        IEnumerable<Role> GetAll();
        void Create(Role entity);
        void Update(Role entity);
        void Delete(Role entity);
        Role GetById(int id);
        Role GetByName(string name);
    }
}
