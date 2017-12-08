using System;
using System.Collections.Generic;

namespace aircharts.net.api.Models
{
    public partial class Charts
    {
        public string Id { get; set; }
        public string Icao { get; set; }
        public string Iata { get; set; }
        public string Country { get; set; }
        public string Airportname { get; set; }
        public string Chartname { get; set; }
        public string Url { get; set; }
        public string Flag { get; set; }
        public string Charttype { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
