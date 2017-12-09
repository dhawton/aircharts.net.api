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
                IOrderedQueryable<Charts> charts;
                if (filter != null)
                {
                    if (filter.Contains(":"))
                    {
                        string[] filterParts = filter.Split(":");
                        charts = context.Charts.Where(m => m.Iata == id || m.Icao == id)
                            .Where(m => m.Charttype == t)
                            .Where(m => m.Charttype == filterParts[0])
                            .Where(m => m.Chartname.Contains(filterParts[1]))
                            .OrderBy(m => m.Chartname);

                    }
                    else
                    {
                        charts = context.Charts.Where(m => m.Iata == id || m.Icao == id)
                            .Where(m => m.Charttype == t)
                            .Where(m => m.Chartname.Contains(filter))
                            .OrderBy(m => m.Chartname);
                    }
                }
                else
                {
                    charts = context.Charts.Where(m => m.Iata == id || m.Icao == id)
                        .Where(m => m.Charttype == t)
                        .OrderBy(m => m.Chartname);
                }
                this.Charts.Add(t, charts);
            }
        }
    }
}
