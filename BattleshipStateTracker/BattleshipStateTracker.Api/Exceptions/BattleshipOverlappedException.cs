using System;

namespace BattleshipStateTracker.Api.Exceptions
{
    public class BattleshipOverlappedException : Exception
    {
        public BattleshipOverlappedException()
        {

        }

        public BattleshipOverlappedException(string message) : base(message)
        {

        }
    }
}
