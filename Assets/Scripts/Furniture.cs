using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    protected Vector3 _eulerAnglesThen;
    protected bool _pointsGiven;
    protected bool _fadeOut;
    protected Points _points;
    [SerializeField] protected GameObject _pointScalerPrefab;
    
    void Start()
    {
        _eulerAnglesThen = transform.up;
        _pointsGiven = false;
        _points = FindObjectOfType<Points>();
    }

    void Explosion()
    {
        _fadeOut = true;
        Destroy(gameObject,1f);
        Destroy(this,1f);
    }
    void Update()
    {
        if ((Time.frameCount % 10) == 0)
        {
            if (!GetComponentInChildren<Renderer>().isVisible)
            {
                var furniRigid = GetComponent<Rigidbody>();
                furniRigid.constraints = RigidbodyConstraints.FreezeRotation;
            }
            else
            {
                var furniRigid = GetComponent<Rigidbody>();
                furniRigid.constraints = RigidbodyConstraints.None;
            }
        }

        var eulerAnglesNow = transform.up;
        if (!_pointsGiven)
        {
            if (Vector3.Dot(eulerAnglesNow, _eulerAnglesThen) < 0.9f)
            {
                _points.ScorePoints.Invoke(100); 
                _pointsGiven = true;
                Instantiate(_pointScalerPrefab, transform.position + new Vector3(0.0f, 4f, 0.0f), Quaternion.Euler(90f,0f,0f));
                Invoke("Explosion", 0.333f);
            }
        }
        else if(_fadeOut)
        {
            transform.localScale /= 1.05f;
        }
    }
}
