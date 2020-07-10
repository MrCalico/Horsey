using System.ComponentModel.DataAnnotations;

namespace Horsey.Domain
{
    public class Standing
    {
        public int RaceId { get; set; }
        /* public Race Race { get; set; }*/
        public int HorseId { get; set; }
        public Horse Horse {get; set; }
        public int Position { get; set; }
        public float Payout { get; set; }
    }
}