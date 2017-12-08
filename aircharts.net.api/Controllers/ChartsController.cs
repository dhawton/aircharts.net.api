using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using aircharts.net.api.Models;
using aircharts.net.api.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aircharts.net.api.Controllers
{
    public class ChartsController : Controller
    {
        private readonly AcDbContext _context;

        public ChartsController(AcDbContext context)
        {
            _context = context;
        }

        [HttpGet("/v3/charts")]
        public async Task<IEnumerable<Chart>> GetCharts()
        {
            return await _context.Charts.Include(m => m.ID).ToListAsync();
        }
    }
}