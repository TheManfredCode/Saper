using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CellsLoader : MonoBehaviour
{
    [SerializeField] private BaseCell _cellPrefab;
    [SerializeField] private BaseCell _bombPrefab;
    [SerializeField] private int _columnCount;
    [SerializeField] private int _rowCount;
    [SerializeField] private int _bombProbability;

    private Random _random;
    
    private void Start()
    {
        _random = new Random();
        var size = _cellPrefab.transform.localScale;

        for (int i = 0; i < _columnCount; i++)
        {
            for (int j = 0; j < _rowCount; j++)
            {
                Vector3 position = new Vector3(size.x * (j), size.y * (i));
                Instantiate(GetPrefab(), position, Quaternion.identity, transform);
            }
        }

        transform.position = new Vector3(- (_rowCount / 2) * size.x, - (_columnCount / 2) * size.y);
    }

    private BaseCell GetPrefab()
    {
        int randomValue = _random.Next(0, 100);

        if (randomValue < _bombProbability)
            return _bombPrefab;

        return _cellPrefab;
    }
}
