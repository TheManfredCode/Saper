using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Saper.Scripts.Cells
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BaseCell : MonoBehaviour
    {
        [SerializeField] private GameObject _hideCover;
        [SerializeField] private GameObject _flag;

        public bool IsPressed { private set; get; }

        public bool IsFlagged => _flag.activeSelf;

        private void OnMouseOver()
        {
            if(Input.GetMouseButtonDown(0))
                OnClick();
            
            if(Input.GetMouseButtonDown(1))
                OnRightClick();
        }

        // private void Update()
        // {
        //     if (Input.GetMouseButtonDown(0))
        //     {
        //         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //         RaycastHit hit;
        //
        //         if (Physics.Raycast(ray, out hit))
        //         {
        //             OnClick();
        //         }
        //     }
        // }
        
        public virtual void OnClick()
        {
            if (IsPressed || IsFlagged) return;
            
            IsPressed = true;
            Open();
        }

        private void OnRightClick()
        {
            _flag.SetActive(!IsFlagged);
        }

        private void Open()
        {
            _hideCover.SetActive(false);
        }
    }
}