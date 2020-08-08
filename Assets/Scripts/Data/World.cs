using UnityEngine;

namespace SweetAndSaltyStudios
{
    public class World
    {
        #region VARIABLES

        private Vector2Int size;
        private Tile[,] tiles;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region CONSTRUCTORS

        public World(Vector2Int size)
        {
            this.size = size;

            CreateTiles();
        }

        public Tile[,] Tiles
        {
            get
            {
                if(tiles == null) return null;

                return tiles;
            }
        }

        public void RandomizeTiles()
        {
            for(int x = 0; x < Tiles.GetLength(0); x++)
                for(int y = 0; y < Tiles.GetLength(1); y++)
                {
                    Tiles[x, y].Type = Random.Range(0, 2) == 0 ? TILE_TYPE.EMPTY : TILE_TYPE.FLOOR;
                }
        }

        #endregion CONSTRUCTORS

        #region CUSTOM_FUNCTIONS

        private void CreateTiles()
        {
            tiles = new Tile[size.x, size.y];

            for(int x = 0; x < tiles.GetLength(0); x++)
                for(int y = 0; y < tiles.GetLength(1); y++)
                {
                    tiles[x, y] = new Tile(this, TILE_TYPE.EMPTY, new Vector2Int(x, y));
                }
        }

        private bool IsPositionInRange(Vector2Int position)
        {
            return position.x > 0 && position.x < size.x && position.y > 0 && position.y < size.y;
        } 

        public Tile GetTile(Vector2Int position)
        {
            if(IsPositionInRange(position) == false) return null;

            return tiles[position.x, position.y];
        }

        #endregion CUSTOM_FUNCTIONS
    }
}