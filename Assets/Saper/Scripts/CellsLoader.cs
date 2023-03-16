using System;
using System.Collections;
using System.Collections.Generic;
using Saper.Scripts.Cells;
using UnityEngine;
using Random = System.Random;

public class CellsLoader : MonoBehaviour
{
    [SerializeField] private EmptyCell _emptyCellPrefab;
    [SerializeField] private BombCell _bombPrefab;
    [SerializeField] private int _rowCount;
    [SerializeField] private int _columnCount;
    [SerializeField] private int _bombCount;

    private Random _random;
    private BaseCell[,] _cells;
    
    private void Start()
    {
        _cells = new BaseCell[_rowCount, _columnCount];
        _random = new Random();

        SetEmptyCells();
        SetBombs();
        SetPosition();
    }
    
    private Vector3 Size => _emptyCellPrefab.transform.localScale;

    private Vector3 GetCellPosition(int columnIndex, int rowIndex)
    {
        return new Vector3(Size.x * (columnIndex), Size.y * (rowIndex));
    }

    private void SetPosition()
    {
        transform.position = new Vector3(- (_columnCount / 2) * Size.x, - (_rowCount / 2) * Size.y);
    }

    private void SetEmptyCells()
    {
        for (int i = 0; i < _rowCount; i++)
        {
            for (int j = 0; j < _columnCount; j++)
            {
                Vector3 position = GetCellPosition(j, i);
                _cells[i, j] = Instantiate(_emptyCellPrefab, position, Quaternion.identity, transform);
            }
        }
    }

    private void SetBombs()
    {
        for (int i = 0; i < _bombCount; i++)
            SetBomb();
    }

    private void SetBomb()
    {
        while (true)
        {
            int i = _random.Next(0, _rowCount);
            int j = _random.Next(0, _columnCount);

            if (_cells[i, j] is BombCell) continue;
            
            Vector3 position = GetCellPosition(j, i);
            _cells[i, j] = Instantiate(_bombPrefab, position, Quaternion.identity, transform);
            IterateBombNeighbourCells(j, i);
            return;
        }
    }

    private void IterateBombNeighbourCells(int columnIndex, int rowIndex)
    {
        for (int i = rowIndex - 1; i <= rowIndex + 1; i++)
            for (int j = columnIndex - 1; j <= columnIndex + 1; j++)
                if(IsIndexInRange(i, j) && _cells[i, j] is EmptyCell)
                    (_cells[i, j] as EmptyCell).IterateCell();
    }

    private bool IsIndexInRange(int rowIndex, int columnIndex)
    {
        return rowIndex < _rowCount && rowIndex >= 0 && columnIndex < _columnCount && columnIndex >= 0;
    }
}
