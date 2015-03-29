using System;

namespace Ground_Movement_Control.Commons
{
    public class CoordinateTuple
    {
        public CoordinateTuple(int x, int y)
        {
            X = x;
            Y = y;
        }

        public CoordinateTuple()
        {
        }

        public Int32 X { get; set; }
        public Int32 Y { get; set; }
    }
}