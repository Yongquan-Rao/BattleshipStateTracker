using BattleshipStateTracker.Api.Exceptions;
using BattleshipStateTracker.Api.Models;
using System;
using System.Collections.Generic;

namespace BattleshipStateTracker.Api.Repositories
{
    public interface IBattleshipBoardRepository
    {
        List<List<int>> CreateBoard();

        List<List<int>> AddBattleship(Battleship battleship);

        AttackResult TakeAttack(Attack attack);
    }

    public class BattleshipBoardRepository : IBattleshipBoardRepository
    {
        private const int LENGTH = 10;
        private List<List<int>> _board;

        public List<List<int>> AddBattleship(Battleship battleship)
        {
            if (_board == null)
            {
                throw new BoardNotFoundException();
            }

            var battleshipInBoard = battleship.BattleshipInBoard;
            for (int i = 0; i < battleshipInBoard.Count; i++)
            {
                var x = battleshipInBoard[i][0];
                var y = battleshipInBoard[i][1];

                if (_board[x][y] != 0)
                {
                    throw new BattleshipOverlappedException();
                }
                
                _board[x][y] = 1;
            }
            return _board;
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

        public AttackResult TakeAttack(Attack attack)
        {
            if (_board == null)
            {
                throw new BoardNotFoundException();
            }

            var x = attack.Position[0];
            var y = attack.Position[1];

            return _board[x][y] == 1 ? AttackResult.HIT : AttackResult.MISS;
        }
    }
}
