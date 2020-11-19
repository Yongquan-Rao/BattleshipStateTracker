using BattleshipStateTracker.Api.Exceptions;
using BattleshipStateTracker.Api.Models;
using System;
using System.Collections.Generic;

namespace BattleshipStateTracker.Api.Repositories
{
    public interface IBattleshipBoardRepository
    {
        List<List<int>> CreateBattleshipBoard();

        List<List<int>> AddBattleship(List<List<int>> battleship);

        AttackState TakeAttack(List<int> attack);
    }

    public class BattleshipBoardRepository : IBattleshipBoardRepository
    {
        private const int LENGTH = 10;
        private List<List<int>> _board;

        public List<List<int>> AddBattleship(List<List<int>> battleship)
        {
            if (_board == null)
            {
                throw new BoardNotFoundException();
            }

            for (int i = 0; i < battleship.Count; i++)
            {
                var x = battleship[i][0];
                var y = battleship[i][1];

                if (x < 0 || x >= LENGTH || y < 0 || y >= LENGTH)
                {
                    throw new BattleshipOverflowException();
                }

                if (_board[x][y] != 0)
                {
                    throw new BattleshipOverlappedException();
                }
                
                _board[x][y] = 1;
            }
            return _board;
        }

        public List<List<int>> CreateBattleshipBoard()
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

        public AttackState TakeAttack(List<int> position)
        {
            if (_board == null)
            {
                throw new BoardNotFoundException();
            }

            var x = position[0];
            var y = position[1];

            return _board[x][y] == 1 ? AttackState.HIT : AttackState.MISS;
        }
    }
}
