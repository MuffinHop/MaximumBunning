using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerLogic : MonoBehaviour
{
    [SerializeField] private Transform _alive;
    [SerializeField] private Transform _eaten;
    private Points _points;
    [SerializeField] private GameObject _pointScalerPrefab;
    [SerializeField] private BunController _bun;
    private bool _pointsGiven;
    private void Start()
    {
        _alive.gameObject.SetActive(true);
        _eaten.gameObject.SetActive(false);
        _points = FindObjectOfType<Points>();
        _bun = FindObjectOfType<BunController>();
        _pointsGiven = false;
    }
    
    void Update()
    {
        // Check for collision with player, if hit do Points event and make flower eaten. Disable collider
        if (!_pointsGiven && Vector3.Distance(_bun.transform.position, transform.position) < 1.0f)
        {
            _alive.gameObject.SetActive(false);
            _eaten.gameObject.SetActive(true);
            _points.ScorePoints.Invoke(100); 
            Instantiate(_pointScalerPrefab, transform.position + new Vector3(0.0f, 4f, 0.0f), Quaternion.Euler(90f,0f,0f));
            _pointsGiven = true;

        }
    }
}
