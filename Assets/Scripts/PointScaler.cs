using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScaler : MonoBehaviour
{
    private double _existed;
    void Start()
    {
        _existed = 0;
        Destroy(gameObject, 2f);
        Destroy(this, 2f);
    }

    void Update()
    {
        _existed += Time.deltaTime;
        if (_existed > 1.0f)
        {
            transform.localScale /= 1.1f;
        }
    }
}
