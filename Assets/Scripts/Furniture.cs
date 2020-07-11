using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    private Vector3 _eulerAnglesThen;
    private bool _pointsGiven;
    private Points _points;
    [SerializeField] private GameObject _pointScalerPrefab;
    
    void Start()
    {
        _eulerAnglesThen = transform.up;
        _pointsGiven = false;
        _points = FindObjectOfType<Points>();
    }

    void Update()
    {
        var eulerAnglesNow = transform.up;
        if (!_pointsGiven)
        {
            if (Vector3.Dot(eulerAnglesNow, _eulerAnglesThen) < 0.9f)
            {
                _points.ScorePoints.Invoke(100); 
                _pointsGiven = true;
                Instantiate(_pointScalerPrefab, transform.position + new Vector3(0.0f, 4f, 0.0f), Quaternion.Euler(90f,0f,0f));
            }
        }
    }
}
