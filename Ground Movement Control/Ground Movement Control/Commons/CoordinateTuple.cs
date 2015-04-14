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

        public static implicit operator CoordinateTuple(VizualizatorWs.CoordinateTuple t)
        {
            var tuple = new CoordinateTuple(t.X, t.Y);
            return tuple;
        }



        public static implicit operator VizualizatorWs.CoordinateTuple(CoordinateTuple t)
        {
            var tuple = new VizualizatorWs.CoordinateTuple();
            tuple.X = t.X;
            tuple.Y = t.Y;
            return tuple;
        }


    }
}