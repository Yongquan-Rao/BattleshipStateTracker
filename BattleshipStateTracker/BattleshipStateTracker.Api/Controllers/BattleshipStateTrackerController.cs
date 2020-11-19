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

        /// <summary>
        /// Create a battleship board
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>A new board</returns>
        [HttpPost("CreateBattleshipBoard")]
        public IActionResult CreateBattleshipBoard()
        {
            var res = _repo.CreateBattleshipBoard();
            return Ok(new CreateBattleshipBoardResponse {  BattleshipBoard = res });
        }

        /// <summary>
        /// Add a battleship to board
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST AddBattleship
        ///     {
        ///         Battleship:[
        ///             [1,2],
        ///             [1,3],
        ///             [1,4]
        ///         ]
        ///     }
        /// </remarks>
        /// <returns>An updated board</returns>
        [HttpPost("AddBattleship")]
        public IActionResult AddBattleship(AddBattleshipRequest request)
        {
            var res = _repo.AddBattleship(request.Battleship);
            return Ok(new AddBattleshipResponse {  BattleshipBoard = res });
        }

        /// <summary>
        /// Take an attack
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST TakeAttack
        ///     {
        ///         Position:
        ///             [1,2]
        ///     }
        /// </remarks>
        /// <returns>An attack state, HIT or MISS</returns>
        [HttpPost("TakeAttack")]
        public IActionResult TakeAttack(AttackRequest request)
        {
            var res = _repo.TakeAttack(request.Position);
            return Ok(new AttackResponse {  Code = (int)res, Message = res.ToString() });
        }
    }
}
