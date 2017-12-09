using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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
        [HttpGet("Airport/{id}")]
        public IActionResult GetCharts([FromRoute] string id)
        {
            Dictionary<string, Airport> chartResults = new Dictionary<string, Airport>();
            string filter = HttpContext.Request.Query["filter"];

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
                    chartResults.Add(airportId, new Airport(_context, airportId, filter));
                }

            }
            else
            {
                chartResults.Add(id, new Airport(_context, id, filter));
            }

            return Ok(chartResults);
        }

        private bool ChartsExists(string id)
        {
            return _context.Charts.Any(e => e.Id == id);
        }
    }
}