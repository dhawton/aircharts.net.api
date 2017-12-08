using System;
using System.Collections.Generic;

namespace aircharts.net.api.Models
{
    public partial class Airports
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CountryId { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public int Elevation { get; set; }
        public string City { get; set; }
        public string Fir { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
