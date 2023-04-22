using Domain.Common;

namespace Domain.Entities
{
    public record class Forward : Player
    {
        public int Goals { get; set; }
    }
}
