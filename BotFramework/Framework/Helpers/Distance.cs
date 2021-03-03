using BotFramework.Framework.Location;
using Microsoft.Xna.Framework;
using System;

namespace BotFramework.Framework.Helpers
{
    /// <summary>
    /// Home of various distance formulas
    /// </summary>
    class Distance
    {
        public static double Manhattan(Tile tile, Tile tile2)
        {
            return Distance.Manhattan(tile.GetTileX(), tile.GetTileY(), tile2.GetTileX(), tile2.GetTileY());
        }

        public static double Manhattan(Point point, Point point2)
        {
            return Distance.Manhattan(point.X, point.Y, point2.X, point2.Y);
        }

        public static double Manhattan(int x, int y, int x2, int y2)
        {
            return Math.Abs(x - x2) + Math.Abs(y - y2);
        }

        public static double Euclidean(Tile tile, Tile tile2)
        {
            return Distance.Euclidean(tile.GetTileX(), tile.GetTileY(), tile2.GetTileX(), tile2.GetTileY());
        }

        public static double Euclidean(Point point, Point point2)
        {
            return Distance.Euclidean(point.X, point.Y, point2.X, point2.Y);
        }

        public static double Euclidean(int x, int y, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x, 2) + Math.Pow(y2 - y, 2));
        }

        public static double AStar(Tile tile, Tile tile2)
        {
            return 0.0;
        }
    }
}
