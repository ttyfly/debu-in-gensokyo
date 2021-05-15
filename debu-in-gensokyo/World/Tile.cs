using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace DebuInGensokyo.World
{
    class TileRepository
    {
        private Dictionary<string,Tile> tileDict;
        private List<Tile> tileList;
        private static TileRepository instance = new TileRepository();
        private TileRepository()
        {
            tileDict = new Dictionary<string, Tile>();
            tileList = new List<Tile>();
            tileList.Add(tileDict["Air"] = new Tile(0, "Air"));
            tileList.Add(tileDict["Soil"] = new Tile(1, "Soil"));
        }
        public static TileRepository Instance
        {
            get { return instance; }
        }
        public Tile GetTile(string name)
        {
            return tileDict[name];
        }
        public Tile GetTile(int id)
        {
            return tileList[id];
        }
        public int Size
        {
            get { return tileList.Count; }
        }
    }
    class Tile
    {
        public const int WIDTH = 8; // pixels
        public const int HEIGHT = 8; // pixels
        private int id;
        private string name;
        private Rectangle textureRectangle;
        public Tile(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public int ID
        {
            get { return id; }
        }
        public Rectangle TextureRectangle
        {
            set { textureRectangle = value; }
            get { return textureRectangle; }
        }
    }
}