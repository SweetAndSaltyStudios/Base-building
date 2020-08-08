using System;
using UnityEngine;

namespace SweetAndSaltyStudios
{
	public class WorldController : MonoBehaviour
	{
        #region VARIABLES

        [Header("World Settings")]
        public Vector2Int Size = new Vector2Int(10, 10);

        [Header("Prefabs")]
        public TileBehaviour TileBehaviour_Prefab;
        public Sprite FloorSprite;

        #endregion VARIABLES

        #region PROPERTIES

        public World CurrentWorld { get; private set; }

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Start()
        {
            CurrentWorld = new World(Size);

            CreateTileBehaviours();

            CurrentWorld.RandomizeTiles();
        }

        private void CreateTileBehaviours()
        {
            for(int x = 0; x < CurrentWorld.Tiles.GetLength(0); x++)
                for(int y = 0; y < CurrentWorld.Tiles.GetLength(1); y++)
                {
                    var position = new Vector2Int(x, y);

                    var tileBehaviour = Instantiate(TileBehaviour_Prefab, (Vector3Int)position, Quaternion.identity, transform);

                    var tile = CurrentWorld.GetTile(position);
                    if(tile != null)
                    {
                        tile.RegisterOnTileChanged_Callback((_tile) => { OnTileTypeChanged(_tile, tileBehaviour); });
                    }
                }
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        private void OnTileTypeChanged(Tile tile, TileBehaviour tileBehaviour)
        {
            if(tile == null || tileBehaviour == null) return;

            tileBehaviour.SpriteRenderer.sprite = tile.Type == TILE_TYPE.FLOOR ? FloorSprite : null;
        }

        #endregion CUSTOM_FUNCTIONS
    }
}