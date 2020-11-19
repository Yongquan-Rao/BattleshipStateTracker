using System.Collections.Generic;

namespace BattleshipStateTracker.Api.Models
{
    public class CreateBattleshipBoardResponse
    {
        public List<List<int>> BattleshipBoard { get; set; }
    }
}
