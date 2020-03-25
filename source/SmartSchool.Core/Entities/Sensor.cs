using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartSchool.Core.Entities
{
    /// <summary>
    /// Sensor mit Messwerten (Measurements)
    /// </summary>
    public class Sensor : EntityObject
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public string Unit { get; set; }
        public ICollection<Measurement> Measurements { get; set; }

        public Sensor()
        {

        }

        public Sensor(string name, string location)
        {
            Name = name;
            Location = location;
        }
    }
}
