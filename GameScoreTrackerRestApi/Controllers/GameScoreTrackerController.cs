using GameScoreTrackerRestApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace GameScoreTrackerRestApi;

[ApiController]
[Route("[controller]")]


public class GameScoreTrackerController : Controller
{
    private readonly GameScoreManager _gameScoreManager;

    public GameScoreTrackerController(GameScoreManager gsc)
    {
        _gameScoreManager = gsc;
    }

    [HttpGet("games")]
    [Authorize]
    public IActionResult Games()
    {
        return Ok(_gameScoreManager.GetGameTitles());
    }

    [HttpGet("players")]
    public IActionResult Players()
    {
        return Ok(_gameScoreManager.GetPlayerNames());
    }

    [HttpGet("gamescores")]
    public IActionResult GetScoresForGame([FromQuery] string title)
    {
        return Ok(_gameScoreManager.GetScoresForGame(title));
    }

    [HttpGet("gamescores/{title}")]
    public IActionResult GetRecordScoresForGame(string title)
    {
        return Ok(_gameScoreManager.GetScoresForGame(title));
    }

    [HttpGet("playerscores")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetRecordScoresForPlayer([FromQuery] /*[FromHeader]*/ string player)
    {
        return Ok(_gameScoreManager.GetScoresForPlayer(player));
    }

    [HttpGet("playergamescores")]
    [ProducesResponseType<ScoreVM>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetRecordScoreForGameForPlayer([FromQuery] string title, [FromQuery] string player)
    {
        var score = _gameScoreManager.GetScoreForPlayerAndGame(player, title);
        return score == null ? NotFound() : Ok(score);
    }

    [HttpPost("player")]
    [Consumes(MediaTypeNames.Application.Json)]
    public IActionResult AddPlayer([FromBody] PlayerVM player)
    {
        _gameScoreManager.AddPlayer(player);
        return Ok(player);
    }

    [HttpPost("game")]
    public IActionResult AddGame([FromBody] GameVM game)
    {
        _gameScoreManager.AddGame(game);
        return Ok(game);
    }

    [HttpPost("score")]
    public IActionResult AddScore([FromBody] ScoreVM score)
    {
        _gameScoreManager.AddScore(score);
        return Ok(score);
    }

    [HttpPut("changeGenre/{gameTitle}")]
    public IActionResult ChangeGenre(string gameTitle, [FromBody] string genre)
    {
        _gameScoreManager.ChangeGenre(gameTitle, genre);
        return Ok();
    }
}
