using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace aircharts.net.api.Models
{
    public enum ChartType
    {
        General,
        Sid,
        Star,
        Intermediate,
        Approach
    }

    public class Chart
    {
        [Key, MaxLength(100)]
        public Guid Id { get; }
        public string Icao { get; }
        public string Iata { get; }
        public string Country { get; }
        public string Airportname { get; }
        public string Chartname { get; }
        public ChartType Charttype { get; }
        public string Url;
        public string Flag;
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
    }
}
