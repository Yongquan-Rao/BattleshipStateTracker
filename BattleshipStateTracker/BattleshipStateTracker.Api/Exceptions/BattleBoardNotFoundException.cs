using System;

namespace BattleshipStateTracker.Api.Exceptions
{
    public class BattleBoardNotFoundException : Exception
    {
        public BattleBoardNotFoundException()
        {

        }

        public BattleBoardNotFoundException(string message) : base(message)
        {

        }
    }
}
