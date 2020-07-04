using System;
using System.Collections.Generic;

namespace Horsey.Domain
{
    public class Horse
    {
        public Horse()
        {
            HealthStats = new List<Health>();
            Races = new List<Race>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public List<Health> HealthStats { get; set; }
        public List<Race> Races { get; set; }
        public int Standing { get; set; }
    }
}
