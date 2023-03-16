using UnityEngine;

namespace Saper.Scripts.Cells
{
    public class EmptyCell : BaseCell
    {
        [SerializeField] private TextMesh _text;

        private int neighbourBombCount;
        
        public void IterateCell()
        {
            neighbourBombCount++;
            _text.text = neighbourBombCount.ToString();
            _text.color = GetTextColor();
        }

        private Color GetTextColor()
        {
            switch (neighbourBombCount)
            {
                case 1:
                    return Color.blue;
                case 2:
                    return Color.green;
                case 3:
                    return Color.red;
                case 4:
                    return Color.cyan;
                case 5:
                    return Color.magenta;
                case 6:
                    return Color.yellow;
                default:
                    return Color.black;
            }
        }
    }
}