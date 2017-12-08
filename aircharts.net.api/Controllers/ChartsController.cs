using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
        // @TODO : Create returnable object as present in PHP v2, use Airport Model?
        [HttpGet("Airport/{id}")]
        public IActionResult GetCharts([FromRoute] string id)
        {
            Dictionary<string, IOrderedQueryable<Charts>> chartResults = new Dictionary<string, IOrderedQueryable<Charts>>();
            IOrderedQueryable<Charts> charts;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id.Contains(","))
            {
                id = id.Replace(" ", String.Empty); // Remove spaces
                string[] ids = id.Split(','); // Now split up list
                foreach (string airportId in ids)
                {
                    charts = _context.Charts.Where(m => m.Iata == airportId || m.Icao == airportId).OrderBy(m => m.Chartname);
                    chartResults.Add(airportId, charts);
                }
            }
            else
            {
                charts = _context.Charts.Where(m => m.Iata == id || m.Icao == id).OrderBy(m => m.Chartname);
                chartResults.Add(id, charts);
            }

            return Ok(chartResults);
        }

        private bool ChartsExists(string id)
        {
            return _context.Charts.Any(e => e.Id == id);
        }
    }
}