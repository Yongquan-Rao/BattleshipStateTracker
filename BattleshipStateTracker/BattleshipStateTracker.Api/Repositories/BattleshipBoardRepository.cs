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

        public List<List<int>> AddBattleship(List<List<int>> battleship)
        {
            if (_board == null)
            {
                throw new BattleBoardNotFoundException("BattleBoardNotFoundException");
            }

            ValidateOverlap(battleship);
            ValidateAlignment(battleship);

            for (int i = 0; i < battleship.Count; i++)
            {
                var x = battleship[i][0];
                var y = battleship[i][1];
                
                _board[x][y] = 1;
            }
            return _board;
        }

        public AttackState TakeAttack(List<int> position)
        {
            if (_board == null)
            {
                throw new BattleBoardNotFoundException("BattleBoardNotFoundException");
            }

            var x = position[0];
            var y = position[1];

            return _board[x][y] == 1 ? AttackState.HIT : AttackState.MISS;
        }

        private void ValidateOverlap(List<List<int>> battleship)
        {
            for (int i = 0; i < battleship.Count; i++)
            {
                var x = battleship[i][0];
                var y = battleship[i][1];

                if (_board[x][y] != 0)
                {
                    throw new BattleshipOverlappedException("BattleshipOverlappedException");
                }
            }
        }

        private void ValidateAlignment(List<List<int>> battleship)
        {
            var battleshipLength = battleship.Count;
            if (battleshipLength >= 2)
            {
                if (battleship[0][0] == battleship[1][0])
                {
                    for (int i = 2; i < battleshipLength; i++)
                    {
                        if (battleship[i][0] != battleship[0][0])
                        {
                            throw new BattleshipNotAlignedException("BattleshipNotAlignedException");
                        }
                    }
                }
                else if (battleship[0][1] == battleship[1][1])
                {
                    for (int i = 2; i < battleshipLength; i++)
                    {
                        if (battleship[i][1] != battleship[0][1])
                        {
                            throw new BattleshipNotAlignedException("BattleshipNotAlignedException");
                        }
                    }
                }
                else
                {
                    throw new BattleshipNotAlignedException("BattleshipNotAlignedException");
                }
            }
        }
    }
}
