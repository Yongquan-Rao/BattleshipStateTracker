using BattleshipStateTracker.Api.Models;
using BattleshipStateTracker.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BattleshipStateTracker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BattleshipStateTrackerController : ControllerBase
    {
        private readonly ILogger<BattleshipStateTrackerController> _logger;
        private readonly IBattleshipBoardRepository _repo;

        public BattleshipStateTrackerController(ILogger<BattleshipStateTrackerController> logger, IBattleshipBoardRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpPost("createboard")]
        public IActionResult CreateBoard()
        {
            var res = _repo.CreateBoard();
            return Ok(res);
        }

        [HttpPost("addbattleship")]
        public IActionResult AddBattleship(Battleship battleship)
        {
            var res = _repo.AddBattleship(battleship);
            return Ok(res);
        }

        [HttpPost("takeattack")]
        public IActionResult TakeAttack(Attack attack)
        {
            var res = _repo.TakeAttack(attack);
            return Ok(res);
        }
    }
}
