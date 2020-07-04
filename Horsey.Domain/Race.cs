using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace Horsey.Domain
{
    public class Race
    {
        public Race()
        {
            Standings = new List<Standing>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<Standing>  Standings { get; set; }
    }
}