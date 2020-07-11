using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BunController : MonoBehaviour
{
    [SerializeField] private Rigidbody _sphere;

    [SerializeField] private float _speed, _currentSpeed;
    [SerializeField] private float _rotate, _currentRotate;
    [SerializeField] private float _driftDirection;
    [SerializeField] private float _driftPower;
    
    [SerializeField] private float _acceleration = 30f;
    [SerializeField] private float _steering = 80f;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _kartNormal;
    [SerializeField] private Transform _bunModel;
    [SerializeField] private Transform _camera;

    void Update()
    {
        _speed = _acceleration * Mathf.Min(Time.time,1f);
        
        //Steer
        if (Input.GetAxis("Horizontal") != 0f)
        {
            int dir = Input.GetAxis("Horizontal") > 0 ? 1 : -1;
            float amount = Mathf.Abs((Input.GetAxis("Horizontal")));
            Steer(dir, amount);
        }
        _currentSpeed = Mathf.SmoothStep(_currentSpeed, _speed, Time.deltaTime * 12f); _speed = 0f;
        _currentRotate = Mathf.Lerp(_currentRotate, _rotate, Time.deltaTime * 4f); _rotate = 0f;
        _bunModel.localEulerAngles = Vector3.Lerp(_bunModel.localEulerAngles, new Vector3(0, 90 + (Input.GetAxis("Horizontal") * 15), _bunModel.localEulerAngles.z), .2f);
        
        transform.position = _sphere.transform.position;
        _camera.position = new Vector3(transform.position.x, _camera.position.y, transform.position.z);
    }
    
    private void FixedUpdate()
    {
        //Forward Acceleration
        _sphere.AddForce(transform.forward * _currentSpeed, ForceMode.Acceleration);


        //Steering
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + _currentRotate, 0), Time.deltaTime * 5f);

        RaycastHit hitOn;
        RaycastHit hitNear;

        Physics.Raycast(transform.position + (transform.up * .1f), Vector3.down, out hitOn, 1.1f, _layerMask);
        Physics.Raycast(transform.position + (transform.up * .1f)   , Vector3.down, out hitNear, 2.0f, _layerMask);

        //Normal Rotation
        _kartNormal.up = Vector3.Lerp(_kartNormal.up, hitNear.normal, Time.deltaTime * 8.0f);
        _kartNormal.Rotate(0, transform.eulerAngles.y, 0);
        transform.position = _sphere.transform.position;
        _camera.position = new Vector3(transform.position.x, _camera.position.y, transform.position.z);
    }

    public void Steer(int direction, float amount)
    {
        _rotate = (_steering * direction) * amount;
    }
    private void Speed(float x)
    {
        _currentSpeed = x;
    }
}
