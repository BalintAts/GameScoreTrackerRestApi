using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameScoreTrackerRestApi.Controllers
{
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



        [HttpGet]
        public string Games()
        {
            return "Doom";
        }

        [HttpGet("players")]
        public string Players()
        {
            return "Bálint";
        }

        // GET: /GameScoreTracker/scores?title={title}
        //[HttpGet("gamescores")]
        //public string GetRecordScoresForGame([FromQuery] string title)
        //{
        //    return title;
        //FromQuery is good for optional parameters
        //}

        [HttpGet("gamescores/{title}")]
        public string GetRecordScoresForGame(string title)
        {
            return title;
        }

        [HttpGet("rank/{title}/{rank:int}")]
        public string GetPlayerOfRankForGame(string title, int rank)
        {
            return $"{title} John";
        }

        [HttpGet("playerscores")]
        public string GetRecordScoresForPlayer([FromQuery] string player)
        {
            return player;
        }

        [HttpGet("playergamescores")]
        public string GetRecordScoreForGameForPlayer([FromQuery] string title,[FromQuery] string player)
        {
            return $"{title}, {player}";
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
}
