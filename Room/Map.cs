using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skylight.Blocks;
using System.Drawing;

namespace Skylight
{
    public class Map
    {
        internal Map(int width, int height)
        {
            for (int x = 0; x < width; x++)
            {
                // Add a new column
                threeDimBlockList.Add(new List<List<Block>>());

                for (int y = 0; y < height; y++)
                {
                    // Add a row for each column
                    threeDimBlockList[threeDimBlockList.Count - 1].Add(new List<Block>());

                    for (int z = 0; z < 2; z++)
                    {
                        // Add a foreground and background for each coordinate
                        threeDimBlockList
                            [threeDimBlockList.Count - 1] // Most recent column
                            [threeDimBlockList[threeDimBlockList.Count - 1].Count - 1] // most recent row
                            .Add(new Block(0, x, y, z));

                        oneDimBlockList.Add(new Block(0, x, y, z));

                    }
                }
            }

        }

        internal List<List<List<Block>>> threeDimBlockList = new List<List<List<Block>>>();
        internal List<Block> oneDimBlockList = new List<Block>();

        public List<List<Block>> RowAt(int y)
        {
            return threeDimBlockList.Select(rows => rows[y]).ToList();
        }

        public List<Block> RowAt(int y, int z)
        {
            return RowAt(y).Select(sublist => sublist[z]).ToList();
        }

        public List<List<Block>> ColumnAt(int x)
        {
            return threeDimBlockList[x];
        }

        public List<Block> ColumnAt(int x, int z)
        {
            return ColumnAt(x).Select(sublist => sublist[z]).ToList();
        }

        public List<Block> BlockAt(int x, int y)
        {
            return threeDimBlockList[x][y];
        }

        public Block BlockAt(int x, int y, int z)
        {
            return threeDimBlockList[x][y][z];
        }

        public void AddBlock(Block b)
        {
            threeDimBlockList[b.X][b.Y][b.Z] = b;
        }

        public List<Block> RegionAt(Point p1, Point p2)
        {
            List<Block> result = new List<Block>();

            for (int x = p1.X; x < p2.X; x++)
                for (int y = p1.Y; y < p2.Y; y++)
                    for (int z = 0; z < 2; z++)
                        result.Add(threeDimBlockList[x][y][z]);

            return result;
        }

        public List<Block> RegionAt(int x1, int y1, int x2, int y2)
        {
            return RegionAt(new Point(x1, y1), new Point(x2, y2));
        }

        public Block RandomBlock()
        {
            return oneDimBlockList[Tools.Ran.Next(oneDimBlockList.Count - 1)];
        }
    }
}
