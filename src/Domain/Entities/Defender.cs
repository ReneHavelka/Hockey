using Domain.Common;

namespace Domain.Entities
{
    public record class Defender : Player
    {
        public int Hits { get; set; }
    }
}
