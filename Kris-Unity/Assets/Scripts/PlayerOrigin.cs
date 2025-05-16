using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerOrigin : MonoBehaviour
{
    public Vector2 CurrentPosition;

    public void UpdatePosition(Vector2 delta)
    {
        CurrentPosition += delta;
        int index = (int)(CurrentPosition.x * 5 + CurrentPosition.y);
        List<GridCell> currentGrid = GameManager.Instance.LevelManager.Builder.Grid;
        if (index < currentGrid.Count && index > 0)
        {
            transform.position = currentGrid[index].transform.position;    
        }
    }   
}
