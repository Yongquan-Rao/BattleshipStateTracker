using System;

namespace BattleshipStateTracker.Api.Exceptions
{
    public class BattleshipNotAlignedException : Exception
    {
        public BattleshipNotAlignedException()
        {

        }

        public BattleshipNotAlignedException(string message) : base(message)
        {

        }
    }
}
