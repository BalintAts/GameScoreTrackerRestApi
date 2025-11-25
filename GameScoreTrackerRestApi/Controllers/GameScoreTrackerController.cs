using GameScoreTrackerRestApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Security.Cryptography.Xml;

namespace GameScoreTrackerRestApi;

[ApiController]
[Route("[controller]")]
//[Route("tracker")]

public class GameScoreTrackerController/*(GameScoreManager gameScoreManager)*/ : Controller
{
    private readonly GameScoreManager _gameScoreManager;

    public GameScoreTrackerController(GameScoreManager gsc)
    {
        _gameScoreManager = gsc;
    }

    public GameScoreTrackerController()
    {

    }

    [HttpGet("games")]
    [Authorize]
    public IActionResult Games()
    {
        return Json(_gameScoreManager.GetGameTitles());
        //return Ok(_gameScoreManager.GetGameTitles());
    }

    [HttpGet("players")]
    public IActionResult Players()
    {
        return Ok(_gameScoreManager.GetPlayerNames());
    }

    //GET: /GameScoreTracker/scores? title = { title }
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
        //return RedirectToAction("Games");
        //return Content(_gameScoreManager.GetScoresForPlayer(player).ToString());
        //return Json(_gameScoreManager.GetScoresForPlayer(player));
        return Ok(_gameScoreManager.GetScoresForPlayer(player));
    }

    [HttpGet("playergamescores")]
    [ProducesResponseType<ScoreVM>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetRecordScoreForGameForPlayer([FromQuery] string title, [FromQuery] string player)
    {
        //return Ok($"title:{title}, player:{player}");
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

    [HttpPut("changeGenre/{gameTitle}")] //probably not the best way
    public IActionResult ChangeGenre(string gameTitle, [FromBody] string genre)
    {
        _gameScoreManager.ChangeGenre(gameTitle, genre);
        return Ok();
    }

    //// GET: GameScoreTrackerRestController
    //public ActionResult Index()
    //{
    //    return 
    //    return View();
    //}

    //// GET: GameScoreTrackerRestController/Details/5
    //public ActionResult Details(int id)
    //{
    //    return View();
    //}

    //// GET: GameScoreTrackerRestController/Create
    //public ActionResult Create()
    //{
    //    return View();
    //}

    //// POST: GameScoreTrackerRestController/Create
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Create(IFormCollection collection)
    //{
    //    try
    //    {
    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}

    //// GET: GameScoreTrackerRestController/Edit/5
    //public ActionResult Edit(int id)
    //{
    //    return View();
    //}

    //// POST: GameScoreTrackerRestController/Edit/5
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Edit(int id, IFormCollection collection)
    //{
    //    try
    //    {
    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}

    //// GET: GameScoreTrackerRestController/Delete/5
    //public ActionResult Delete(int id)
    //{
    //    return View();
    //}

    //// POST: GameScoreTrackerRestController/Delete/5
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Delete(int id, IFormCollection collection)
    //{
    //    try
    //    {
    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}
}
