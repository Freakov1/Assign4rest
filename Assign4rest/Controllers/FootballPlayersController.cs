using MandatoryAssignment;
using Microsoft.AspNetCore.Mvc;

namespace Assign4rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayersController : ControllerBase
    {
        private readonly FootballPlayersManager _manager = new FootballPlayersManager();

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> GetAll()
        {
            IEnumerable<FootballPlayer> players = _manager.GetAll();
            if (players == null) return NotFound("No list found");
            return Ok(players);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> GetByID(int id)
        {
            FootballPlayer player = _manager.GetById(id);
            if (player == null) return NotFound("No such class id: " + id);
            return Ok(player);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Post([FromBody] FootballPlayer value)
        {
            FootballPlayer player = _manager.AddPlayer(value);
            if (player == null) return NotFound("cant find object");
            return Created("api/IPAs/" + player.ID, player);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Put(int id, [FromBody] FootballPlayer value)
        {
            FootballPlayer player = _manager.UpdatePlayer(id, value);
            if (player == null) return NotFound("Cant find object");
            return Ok(player);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            FootballPlayer player = _manager.DeletePlayer(id);
            if (player == null) return NotFound("No object to be deleted was found");
            return Accepted(player);
        }
    }
}
