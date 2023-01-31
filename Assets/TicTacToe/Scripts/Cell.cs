using System;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Text label;

        private void Awake()
        {
            button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            label.text = "X";
            
            button.onClick.RemoveListener(OnButtonClick);
            button.interactable = false;
        }
    }
}