using System;
using UnityEngine;

namespace SweetAndSaltyStudios
{
    public class Tile
	{
        #region VARIABLES

        private Action<Tile> OnTypeChanged_Callback = delegate { };

        private readonly World world;
        private TILE_TYPE type;

        #endregion VARIABLES

        #region PROPERTIES

        public Vector2Int Position { get; }

        public TILE_TYPE Type
        {
            get
            {
                return type;
            }
            set
            {
                if(type == value) return;

                type = value;

                OnTypeChanged_Callback(this);
            }
        }

        #endregion PROPERTIES

        #region CONSTRUCTORS

        public Tile(World world, TILE_TYPE type, Vector2Int position)
        {
            this.world = world;
            this.type = type;
            Position = position;
        }

        #endregion CONSTRUCTORS

        #region CUSTOM_FUNCTIONS

        public void RegisterOnTileChanged_Callback(Action<Tile> callback)
        {
            OnTypeChanged_Callback += callback;
        }

        public void UnregisterOnTileChanged_Callback(Action<Tile> callback)
        {
            OnTypeChanged_Callback += callback;
        }

        #endregion CUSTOM_FUNCTIONS
    }
}