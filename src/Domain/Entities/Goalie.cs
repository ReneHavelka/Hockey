using Domain.Common;

namespace Domain.Entities
{
    public record class Goalie : Player
    {
        public int Wins { get; set; }
    }
}
