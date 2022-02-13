using System;
using System.Collections.Generic;

namespace BlazorVer3.Models
{
    public partial class GoogleMapsPin
    {
        public float? Lng { get; set; }
        public float? Lat { get; set; }
        public string? AddressStr { get; set; }
        public string? Description { get; set; }
        public string PinName { get; set; } = null!;
    }
}
