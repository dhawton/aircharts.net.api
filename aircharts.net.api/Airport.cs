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

        public Airport(AirchartContext context, string id, string filter = null)
        {
            this.Info = context.Airports.First(a => a.Id == id);
            string[] types = {"General", "SID", "STAR", "Intermediate", "Approach"};
            foreach (string t in types)
            {
                IQueryable<Charts> charts;
                string chartType = null;
                if (filter != null && filter.Contains(":")) {
                    string[] filterParts = filter.Split(":");
                    chartType = filterParts[0];
                    filter = filterParts[1];
                }
                charts = context.Charts
                                .Where(m => m.Icao == id || m.Iata == id)
                                .Where(m => m.Charttype == t);
                if (chartType!= null) {
                    charts = charts.Where(m => m.Charttype == chartType);
                }
                if (filter != null) {
                    charts = charts.Where(m => m.Chartname.Contains(filter));
                }

                this.Charts.Add(t, charts.OrderBy(m => m.Chartname));
            }
        }
    }
}
