using AoCLib.Models;

namespace AoCLib.Extensions
{
    public static class SlopeExtensions
    {
        public static int CheckSlopeTrees(this string[] lines, Slope slope)
        {
            var horizontalPos = slope.Right;
            var treeChar = '#';
            var treeNum = 0;
            string line;
            for (int verticalPos = slope.Down; verticalPos < lines.Length; verticalPos += slope.Down)
            {
                line = lines[verticalPos];
                if (line[horizontalPos % line.Length] == treeChar)
                {
                    treeNum++;
                }

                horizontalPos += slope.Right;
            }

            return treeNum;
        }
    }
}