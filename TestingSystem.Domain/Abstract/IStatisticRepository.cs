using TestingSystem.Domain.Entities;
using System.Collections.Generic;

namespace TestingSystem.Domain.Abstract
{
    public interface IStatisticRepository
    {
        IEnumerable<Statistic> GetAll();
        void Create(Statistic entity);
        void Update(Statistic entity);
        void Delete(Statistic entity);
        bool IsUserPassedTest(int userId, int testId);
        Statistic GetStatistic(int userId, int testId);
        IEnumerable<Statistic> GetByUserId(int id);
        IEnumerable<Statistic> GetByTestId(int id);
        IEnumerable<Statistic> FilterStatistic(int? testId, StatisticSortType sortType);
    }
}
