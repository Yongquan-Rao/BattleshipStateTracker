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

        [HttpPost("createbattleshipboard")]
        public IActionResult CreateBattleshipBoard()
        {
            var res = _repo.CreateBattleshipBoard();
            return Ok(new CreateBattleshipBoardResponse {  BattleshipBoard = res });
        }

        [HttpPost("addbattleship")]
        public IActionResult AddBattleship(AddBattleshipRequest request)
        {
            var res = _repo.AddBattleship(request.Battleship);
            return Ok(new AddBattleshipResponse {  BattleshipBoard = res });
        }

        [HttpPost("takeattack")]
        public IActionResult TakeAttack(AttackRequest request)
        {
            var res = _repo.TakeAttack(request.Position);
            return Ok(new AttackResponse {  Code = (int)res, Message = res.ToString() });
        }
    }
}
