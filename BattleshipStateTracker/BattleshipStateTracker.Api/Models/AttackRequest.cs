using System.Collections.Generic;

namespace BattleshipStateTracker.Api.Models
{
    public class AttackRequest
    {
        public List<int> Position { get; set; }
    }
}
