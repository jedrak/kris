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
        transform.position = GameManager.Instance.LevelBuilder.Grid[index].transform.position;
    }

    // private void Update()
    // {
    //     transform.position = CurrentPosition;
    // }
}
