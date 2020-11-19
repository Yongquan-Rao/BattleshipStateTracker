using System.Collections.Generic;

namespace BattleshipStateTracker.Api.Models
{
    public class AddBattleshipRequest
    {
        public List<List<int>> Battleship { get; set; }
    }
}
