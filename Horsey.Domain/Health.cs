namespace Horsey.Domain
{
    public class Health
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Strain";
        public string Description { get; set; } = "Left front shoulder strain";
        public int Holistity { get; set; } = -25;
    }
}