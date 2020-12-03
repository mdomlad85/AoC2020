namespace AoCLib.Models
{
    public class Slope
    {
        public ushort Right { get; }
        public ushort Down { get; }

        public Slope(ushort right, ushort down)
        {
            Right = right;
            Down = down;
        }
    }
}