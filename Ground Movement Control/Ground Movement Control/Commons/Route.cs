using System;
using System.Collections.Generic;

namespace Ground_Movement_Control.Commons
{
    public class Route
    {
        public Route(Location @from, Location to, List<CoordinateTuple> points)
        {
            From = @from;
            To = to;
            Points = points;
        }

        public Route()
        {
        }

        public Location From { get; set; }
        public Location To { get; set; }
        public List<CoordinateTuple> Points { get; set; }
    }
}