using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    protected Vector2Int _gridPosition;
    protected Pointer _pointer;

    protected virtual void CheckConnections()
    {
    }
    public void SetGridPoint(Vector2Int gridPosition)
    {
        _gridPosition = gridPosition;
    }
    public void SetPointer(Pointer pointer)
    {
        _pointer = pointer;
        _pointer.EnviromentChanged.AddListener(CheckConnections);
    }
}
