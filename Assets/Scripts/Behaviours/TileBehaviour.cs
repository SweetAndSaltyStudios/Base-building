using UnityEngine;

namespace SweetAndSaltyStudios
{
	public class TileBehaviour : MonoBehaviour
	{
        #region VARIABLES

        private SpriteRenderer spriteRenderer;

        #endregion VARIABLES

        #region PROPERTIES

        public SpriteRenderer SpriteRenderer { get { return spriteRenderer ?? (spriteRenderer = GetComponentInChildren<SpriteRenderer>()); } }

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
            name = $"Tile ( {transform.position.x} , {transform.position.y} )";
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        #endregion CUSTOM_FUNCTIONS
    }
}