using System.Collections.Generic;

namespace BattleshipStateTracker.Api.Models
{
    public class AddBattleshipResponse
    {
        public List<List<int>> BattleshipBoard { get; set; }
    }
}
