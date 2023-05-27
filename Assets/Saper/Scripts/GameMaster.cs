using Saper.Scripts.Cells;
using UnityEngine;

namespace Saper.Scripts
{
    public class GameMaster : MonoBehaviour
    {
        [SerializeField] private CellsLoader _loader;
        [SerializeField] private Camera _camera;

        private Ray TouchRay => _camera.ScreenPointToRay(Input.mousePosition);

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleTouch();
            }
            // else if (Input.GetMouseButtonDown(1))
            // {
            //     HandleAlternativeTouch();
            // }
        }

        private void HandleTouch()
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            BaseCell tile = _loader.GetCell(worldPosition);
            if (tile != null)
            {
                tile.OnClick();
            }
        }

    }
}