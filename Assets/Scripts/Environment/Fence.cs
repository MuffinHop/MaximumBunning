using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : Environment
{
    [SerializeField] private Transform _southConnector;
    [SerializeField] private Transform _northConnector;
    [SerializeField] private Transform _eastConnector;
    [SerializeField] private Transform _westConnector;

    protected override void CheckConnections()
    {
        if (_pointer.GetEnvironment(_gridPosition.x, _gridPosition.y - 1) != null)
        {
            SetSouthConnector(true);
        }
                    
        if (_pointer.GetEnvironment(_gridPosition.x, _gridPosition.y + 1) != null)
        {
            SetNorthConnector(true);
        }
                    
        if (_pointer.GetEnvironment(_gridPosition.x - 1, _gridPosition.y) != null)
        {
            SetWestConnector(true);
        }
                    
        if (_pointer.GetEnvironment(_gridPosition.x + 1, _gridPosition.y) != null)
        {
            SetEastConnector(true);
        }
    }
    private void SetSouthConnector(bool active)
    {
        _southConnector.gameObject.SetActive(active);
    }
    private void SetNorthConnector(bool active)
    {
        _northConnector.gameObject.SetActive(active);
    }
    private void SetEastConnector(bool active)
    {
        _eastConnector.gameObject.SetActive(active);
    }
    private void SetWestConnector(bool active)
    {
        _westConnector.gameObject.SetActive(active);
    }
}
