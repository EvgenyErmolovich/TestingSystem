using TestingSystem.Domain.Abstract;
using TestingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TestingSystem.Domain.Concrete
{
    public class EFStatisticRepository : IStatisticRepository
    {
        private readonly DbContext context;

        public EFStatisticRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Statistic> GetByUserId(int id)
        {
            return context.Set<Statistic>().Where(s => s.UserId == id);
        }

        public IEnumerable<Statistic> GetByTestId(int id)
        {
            return context.Set<Statistic>().Where(s => s.TestId == id);
        }

        public IEnumerable<Statistic> GetAll()
        {
            return context.Set<Statistic>();
        }

        public Statistic GetStatistic(int userId, int testId)
        {
            Statistic statistic = context.Set<Statistic>()
                .FirstOrDefault(s => s.TestId == testId && s.UserId == userId);
            return statistic;
        }

        public void Create(Statistic entity)
        {
            context.Set<Statistic>().Add(entity);
            context.SaveChanges();
        }

        public void Update(Statistic entity)
        {
            Statistic statisticToUpdate = context.Set<Statistic>()
                .FirstOrDefault(s => s.UserId == entity.UserId && s.TestId == entity.TestId);
            context.Entry(statisticToUpdate).CurrentValues.SetValues(entity);
            context.SaveChanges();
        }

        public void Delete(Statistic entity)
        {
            Statistic statistic = context.Set<Statistic>()
                .FirstOrDefault(s => s.UserId == entity.UserId && s.TestId == entity.TestId);
            context.Set<Statistic>().Remove(statistic);
            context.SaveChanges();
        }

        public bool IsUserPassedTest(int userId, int testId)
        {
            Statistic statistic = context.Set<Statistic>()
                .FirstOrDefault(s => s.TestId == testId && s.UserId == userId);
            return (statistic != null);
        }

        public IEnumerable<Statistic> FilterStatistic(int? testId, StatisticSortType sortType)
        {
            IEnumerable<Statistic> statictics;
            statictics = (testId != null && testId != 0) ? GetByTestId((int)testId) : GetAll();
            switch (sortType)
            {
                case StatisticSortType.Date:
                    statictics = statictics.OrderByDescending(s => s.Date);
                    break;

                case StatisticSortType.Time:
                    statictics = statictics.OrderBy(s => s.Time);
                    break;

                case StatisticSortType.Percentage:
                default:
                    statictics = statictics.OrderByDescending(s => s.Percentage);
                    break;
            }
            return statictics;
        }
    }
}
