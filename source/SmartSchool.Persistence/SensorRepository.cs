using SmartSchool.Core.Contracts;
using SmartSchool.Core.Entities;
using System.Linq;

namespace SmartSchool.Persistence
{
    public class SensorRepository : ISensorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SensorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Sensor[] GetAll()
        {
            return _dbContext.Sensors
                .OrderBy(sensor => sensor.Name)
                .ToArray();
        }

        
    }
}