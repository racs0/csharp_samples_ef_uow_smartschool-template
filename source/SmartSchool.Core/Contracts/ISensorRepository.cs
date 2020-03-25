using SmartSchool.Core.Entities;

namespace SmartSchool.Core.Contracts
{
    public interface ISensorRepository
    {
        Sensor[] GetAll();
    }
}
