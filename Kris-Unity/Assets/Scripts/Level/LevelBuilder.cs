using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public GridCell GridCellPrefab;
    private List<GridCell> m_Grid = new List<GridCell>();
    public List<GridCell> Grid => m_Grid;
    [SerializeField] private float m_Mul;
    public void BuildLevel(LevelData levelData)
    {
        
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GridCell cell = Instantiate(GridCellPrefab, Vector3.zero, Quaternion.identity);
                cell.transform.SetParent(transform);
                cell.transform.position = new Vector3(i*m_Mul, 0, j*m_Mul);
                m_Grid.Add(cell);
            }
        }
    }

    private void Awake()
    {
        BuildLevel(null);
    }
}
