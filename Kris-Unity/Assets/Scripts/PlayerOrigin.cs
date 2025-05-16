using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerOrigin : MonoBehaviour
{
    public Vector2 CurrentPosition;

    public void UpdatePosition(Vector2 delta)
    {
        Vector2 buffer = CurrentPosition + delta;
        int index = (int)(buffer.x * 5 + buffer.y);
        List<GridCell> currentGrid = GameManager.Instance.LevelManager.Builder.Grid;
        Debug.Log(index);
        if (index < currentGrid.Count && index >= 0  && buffer.x < 5 && buffer.x >= 0 && buffer.y < 5 && buffer.y >= 0)
        {
            CurrentPosition += delta;
            transform.position = currentGrid[index].transform.position;    
        }
    }   
}
