using System;
using UnityEngine;

namespace SweetAndSaltyStudios
{
	public class MouseController : MonoBehaviour
	{
        #region VARIABLES

        private Camera mainCamera;
        private WorldController worldController;

        public Transform Cursor;
        private Vector2 mouseCurrentFramePosition;
        private Vector2 mouseLastFramePosition;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
            mainCamera = Camera.main;
            worldController = FindObjectOfType<WorldController>();
        }

        private void Start()
        {
            if(mainCamera == null)
            {
                Debug.LogError("There is no camera with tag 'Main Camera' in the scene!");
            }
        }

        private void Update()
        {
            mouseCurrentFramePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            HandleLeftMouseButton();
            HandleRightMouseButton();

            mouseLastFramePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        private void HandleLeftMouseButton()
        {
            if(Input.GetMouseButtonDown(0))
            {
              
            }

            if(Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.LeftControl))
            {
                var tileUnderMouse = GetTileAtWoorldPosition(mouseCurrentFramePosition);

                if(tileUnderMouse != null)
                {
                    tileUnderMouse.Type = tileUnderMouse.Type == TILE_TYPE.EMPTY ? TILE_TYPE.FLOOR : TILE_TYPE.EMPTY;
                }
            }

            if(Input.GetMouseButton(0))
            {
                HandleCursorSnapPosition();
            }


            if(Input.GetMouseButtonUp(0))
            {

            }
        }

        private void HandleCursorSnapPosition()
        {
            var tileUnderMouse = GetTileAtWoorldPosition(mouseCurrentFramePosition);

            if(tileUnderMouse != null)
            {
                if(Cursor.gameObject.activeSelf == false)
                    Cursor.gameObject.SetActive(true);

                Cursor.transform.position = (Vector3Int)tileUnderMouse.Position;
                return;
            }

            if(Cursor.gameObject.activeSelf == true)
                Cursor.gameObject.SetActive(false);
        }

        private void HandleRightMouseButton()
        {
            if(Input.GetMouseButtonDown(1))
            {
               
            }

            if(Input.GetMouseButton(1))
            {
                mainCamera.transform.Translate(mouseCurrentFramePosition - mouseLastFramePosition);

            }

            if(Input.GetMouseButtonUp(1))
            {
            }


        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        private Tile GetTileAtWoorldPosition(Vector3 worldPosition)
        {
            var position = new Vector2Int(
                Mathf.RoundToInt(worldPosition.x), 
                Mathf.RoundToInt(worldPosition.y));

            return worldController.CurrentWorld.GetTile(position);
        }

        #endregion CUSTOM_FUNCTIONS
    }
}