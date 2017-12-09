using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aircharts.net.api.Models;

namespace aircharts.net.api
{
    public class Airport
    {
        public Airports Info;
        public Dictionary<string, IOrderedQueryable<Charts>> Charts = new Dictionary<string, IOrderedQueryable<Charts>>();
        private readonly AirchartContext _context;

        public Airport(AirchartContext context, string id)
        {
            _context = context;
            IOrderedQueryable<Charts> charts;

            this.Info = _context.Airports.First(a => a.Id == id);
            string[] types = {"General", "SID", "STAR", "Intermediate", "Approach"};
            foreach (string t in types)
            {
                charts = _context.Charts.Where(m => m.Iata == id || m.Icao == id)
                    .Where(m => m.Charttype == t)
                    .OrderBy(m => m.Chartname);
                this.Charts.Add(t, charts);
            }
        }
    }
}
