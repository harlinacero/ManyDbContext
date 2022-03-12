using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoulleteApi.Application;
using RoulleteApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoulleteApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouletteController : ControllerBase
    {
        private readonly RouletteAppService _rouletteAppService;

        public RouletteController(RouletteAppService rouletteAppService)
        {
            this._rouletteAppService = rouletteAppService;
        }

        [HttpPost(nameof(Save))]
        public Roulette Save(Roulette roulette)
        {
            return _rouletteAppService.Save(roulette);
        }

        [HttpGet(nameof(GetRoulettes))]
        public IEnumerable<Roulette> GetRoulettes()
        {
            return _rouletteAppService.GetRoulettes();
        }

        [HttpGet(nameof(GetRouletteById))]
        public Roulette GetRouletteById(string id)
        {
            return _rouletteAppService.GetRouletteById(id);
        }
    }
}
