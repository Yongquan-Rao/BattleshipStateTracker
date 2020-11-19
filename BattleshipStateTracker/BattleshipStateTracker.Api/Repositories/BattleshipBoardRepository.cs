using System;
using System.Collections.Generic;

namespace BattleshipStateTracker.Api.Repositories
{
    public interface IBattleshipBoardRepository
    {
        List<List<int>> CreateBoard();

        bool AddBattleship();

        bool TakeAttack();
    }

    public class BattleshipBoardRepository : IBattleshipBoardRepository
    {
        private const int LENGTH = 10;
        private List<List<int>> _board;

        public bool AddBattleship()
        {
            throw new NotImplementedException();
        }

        public List<List<int>> CreateBoard()
        {
            _board = new List<List<int>>();
            for (int i = 0; i < LENGTH; i++)
            {
                var row = new List<int>();
                for (int j = 0; j < LENGTH; j++)
                {
                    row.Add(0);
                }
                _board.Add(row);
            }

            return _board;
        }

        public bool TakeAttack()
        {
            throw new NotImplementedException();
        }
    }
}
