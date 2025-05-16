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

    [SerializeField] private PlayerOrigin m_PlayerPrefab;
    public void BuildLevel(LevelData levelData)
    {
        GameManager.Instance.LevelManager.Builder.Grid.Clear();
        GameManager.Instance.LevelManager.SetCurrentLevelData(levelData);
        // First Pass - build grid
        for (int i = 0; i < levelData.Size.x; i++)
        {
            for (int j = 0; j < levelData.Size.y; j++)
            {
                GridCell cell = Instantiate(GridCellPrefab, Vector3.zero, Quaternion.identity);
                cell.transform.SetParent(GameManager.Instance.LevelManager.transform);
                cell.transform.position = new Vector3(i*m_Mul, 0, j*m_Mul);
                m_Grid.Add(cell);
            }
        }
        
        // Place player
        int index = levelData.Content.Replace("\n", String.Empty).IndexOf("p");
        if (index > 0 && index < levelData.Content.Length)
        {
            PlayerOrigin player = Instantiate(m_PlayerPrefab, Vector3.zero, Quaternion.identity);
            player.transform.SetParent(GameManager.Instance.LevelManager.transform);
            player.UpdatePosition(Grid[index]);
            GameManager.Instance.SubscribePlayer(player);
        }
        
        
    }
    
}
