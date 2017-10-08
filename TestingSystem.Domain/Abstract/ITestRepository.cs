using TestingSystem.Domain.Entities;
using System.Collections.Generic;

namespace TestingSystem.Domain.Abstract
{
    public interface ITestRepository
    {
        IEnumerable<Test> GetAll();
        void Create(Test entity);
        void Update(Test entity);
        void Delete(Test entity);
        Test GetById(int id);
        Test GetByName(string name);
        IEnumerable<Test> GetAllReady();
        IEnumerable<Test> SearchAllTestsByKeyWord(string keyWord);
        IEnumerable<Test> SearchAllReadyTestsByKeyWord(string keyWord);
    }
}
