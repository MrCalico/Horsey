using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Data
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

    public class Race
    {
        public Race()
        {
            Standings = new List<Standing>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<Standing> Standings { get; set; }
    }

    public class Health
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Strain";
        public string Description { get; set; } = "Left front shoulder strain";
        public int Holistity { get; set; } = -25;
    }

    public class Standing
    {
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public int HorseId { get; set; }
        public Horse Horse { get; set; }
        public int Position { get; set; }
        public float Payout { get; set; }
    }
}
