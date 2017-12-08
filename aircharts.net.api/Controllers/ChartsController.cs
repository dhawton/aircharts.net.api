using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aircharts.net.api.Models;

namespace aircharts.net.api.Controllers
{
    [Produces("application/json")]
    [Route("v2/")]
    public class ChartsController : Controller
    {
        private readonly AirchartContext _context;

        public ChartsController(AirchartContext context)
        {
            _context = context;
        }

        // GET: /v2/Airport/{id}
        // @TODO : Add support for multiple airports in list, IE: {id},{id},{id}
        [HttpGet("Airport/{id}")]
        public IActionResult GetCharts([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var charts = _context.Charts.Where(m => m.Iata == id || m.Icao == id).OrderBy(m => m.Chartname);

            if (charts == null)
            {
                return NotFound();
            }

            return Ok(charts);
        }

        private bool ChartsExists(string id)
        {
            return _context.Charts.Any(e => e.Id == id);
        }
    }
}