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
    [Route("api/Charts")]
    public class ChartsController : Controller
    {
        private readonly AirchartContext _context;

        public ChartsController(AirchartContext context)
        {
            _context = context;
        }

        // GET: api/Charts
        [HttpGet]
        public IEnumerable<Charts> GetCharts()
        {
            return _context.Charts;
        }

        // GET: api/Charts/airport
        [HttpGet("{id}")]
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

        // PUT: api/Charts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharts([FromRoute] string id, [FromBody] Charts charts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != charts.Id)
            {
                return BadRequest();
            }

            _context.Entry(charts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChartsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Charts
        [HttpPost]
        public async Task<IActionResult> PostCharts([FromBody] Charts charts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Charts.Add(charts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharts", new { id = charts.Id }, charts);
        }

        // DELETE: api/Charts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharts([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var charts = await _context.Charts.SingleOrDefaultAsync(m => m.Id == id);
            if (charts == null)
            {
                return NotFound();
            }

            _context.Charts.Remove(charts);
            await _context.SaveChangesAsync();

            return Ok(charts);
        }

        private bool ChartsExists(string id)
        {
            return _context.Charts.Any(e => e.Id == id);
        }
    }
}