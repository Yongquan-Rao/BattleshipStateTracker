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

        [HttpPost]
        public IActionResult AddBattleship()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult TakeAttack()
        {
            return Ok();
        }
    }
}
