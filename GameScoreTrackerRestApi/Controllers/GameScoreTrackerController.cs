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

    //todo: null handling in the following way:
    //var score = _gameScoreManager.GetScoreForPlayerAndGame(player, title);
    //    return score == null ? NotFound() : Ok(score);

    // todo: handle cancelling

    public GameScoreTrackerController(GameScoreManager gsc)
    {
        _gameScoreManager = gsc;
    }

    [HttpGet("games")]
    [ProducesResponseType<ScoreVM>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Games(CancellationToken ct)
    {
        return Ok(await _gameScoreManager.GetGameTitles(ct));
    }

    [HttpGet("players")]
    [ProducesResponseType<ScoreVM>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Players(CancellationToken ct)
    {
        return Ok(await _gameScoreManager.GetPlayerNames(ct));
    }

    [HttpGet("gamescores")]
    [ProducesResponseType<ScoreVM>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetScoresForGame([FromQuery] string title, CancellationToken ct)
    {
        return Ok(await _gameScoreManager.GetScoresForGame(title, ct));
    }

    [HttpGet("gamescores/{title}")]
    [ProducesResponseType<ScoreVM>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetRecordScoresForGame(string title, CancellationToken ct)
    {
        return Ok(await _gameScoreManager.GetScoresForGame(title, ct));
    }

    [HttpGet("playerscores")]
    [ProducesResponseType<ScoreVM>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetRecordScoresForPlayer([FromQuery] /*[FromHeader]*/ string player, CancellationToken ct)
    {
        return Ok(await _gameScoreManager.GetScoresForPlayer(player, ct));
    }

    [HttpGet("playergamescores")]
    [ProducesResponseType<ScoreVM>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetRecordScoreForGameForPlayer([FromQuery] string title, [FromQuery] string player, CancellationToken ct)
    {
        return Ok(await _gameScoreManager.GetScoreForPlayerAndGame(player, title, ct));
    }

    [HttpPost("player")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Authorize]
    [ProducesResponseType<ScoreVM>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddPlayer([FromBody] PlayerVM player, CancellationToken ct)
    {
        await _gameScoreManager.AddPlayer(player, ct); 
        return Ok(player);
    }

    [HttpPost("game")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Authorize]
    [ProducesResponseType<ScoreVM>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async  Task<IActionResult> AddGame([FromBody] GameVM game, CancellationToken ct)
    {
        await _gameScoreManager.AddGame(game, ct);
        return Ok(game);
    }

    [HttpPost("score")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Authorize]
    [ProducesResponseType<ScoreVM>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddScore([FromBody] ScoreVM score, CancellationToken ct)
    {
        await _gameScoreManager.AddScore(score, ct);
        return Ok(score);
    }

    [HttpPut("changeGenre/{gameTitle}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Authorize]
    [ProducesResponseType<ScoreVM>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult>  ChangeGenre(string gameTitle, [FromBody] string genre, CancellationToken ct)
    {
        await _gameScoreManager.ChangeGenre(gameTitle, genre, ct);
        return Ok();
    }
}
