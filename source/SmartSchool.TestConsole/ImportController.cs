using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SmartSchool.Core.Entities;
using Utils;

namespace SmartSchool.TestConsole
{
    public class ImportController
    {
        const string Filename = "measurements.csv";

        /// <summary>
        /// Liefert die Messwerte mit den dazugehörigen Sensoren
        /// </summary>
        public static IEnumerable<Measurement> ReadFromCsv()
        {
            string path = MyFile.GetFullNameInApplicationTree(Filename);
            if (!File.Exists(path))
            {
                return null;
            }

            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            Dictionary<string, Sensor> sensors = new Dictionary<string, Sensor>();
            List<Measurement> measurements = new List<Measurement>();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(';');
                string value = fields[2];

                if (!sensors.ContainsKey(value))
                {
                    string[] splitValue = value.Split('_');
                    Sensor sensor = new Sensor(value, splitValue[0]);
                    sensors.Add(value, sensor);
                }
            }

            for (int j = 1; j < lines.Length; j++)
            {
                string[] fields = lines[j].Split(';');
                Sensor sensor = sensors[fields[2]];
                DateTime time = DateTime.Parse($"{fields[0]} {fields[1]}");
                double value = Double.Parse(fields[3]);
                Measurement measurement = new Measurement(sensor, time, value);
                measurements.Add(measurement);
                sensor.Measurements = new List<Measurement>();
                sensor.Measurements.Add(measurement);
            }

            return measurements;
        }

       
        

    }
}
 