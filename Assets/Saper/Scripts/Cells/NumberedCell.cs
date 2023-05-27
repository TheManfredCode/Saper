using UnityEngine;
using UnityEngine.Events;

namespace Saper.Scripts.Cells
{
    public class NumberedCell : BaseCell
    {
        [SerializeField] private TextMesh _text;

        private int _neighbourBombCount;
        private int _rowIndex;
        private int _columnIndex;

        public event UnityAction<int, int> EmptyCellClicked;
        public event UnityAction CellClicked;
        
        public void IterateCell()
        {
            _neighbourBombCount++;
            _text.text = _neighbourBombCount.ToString();
            _text.color = GetTextColor();
        }

        private Color GetTextColor()
        {
            switch (_neighbourBombCount)
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

        public override void OnClick()
        {
            if (IsPressed) return;

            base.OnClick();
            
            CellClicked.Invoke();

            if(_neighbourBombCount == 0)
                EmptyCellClicked?.Invoke(_rowIndex, _columnIndex);
        }

        public void SetIndexes(int rowIndex, int columnIndex)
        {
            _rowIndex = rowIndex;
            _columnIndex = columnIndex;
        }
    }
}