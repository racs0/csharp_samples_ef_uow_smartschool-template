using SmartSchool.Core.Contracts;
using SmartSchool.Core.Entities;
using System.Linq;

namespace SmartSchool.Persistence
{
    public class MeasurementRepository : IMeasurementRepository
    {
        private ApplicationDbContext _dbContext;

        public MeasurementRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRange(Measurement[] measurements)
        {
            _dbContext.Measurements.AddRange(measurements);
        }

        //public int MeasurementCount(Sensor sensor)
        //{
        //    return _dbContext.Measurements.Where(s => s.Sensor.Name == sensor.Name && s.Sensor.Location == sensor.Location).Count();
        //}
    }
}