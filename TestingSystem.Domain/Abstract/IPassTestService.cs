using TestingSystem.Domain.Entities;

namespace TestingSystem.Domain.Abstract
{
    public interface IPassTestService
    {
        Statistic PassTest(PassTestModel passTest);
    }
}
