using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BunController : MonoBehaviour
{
    [SerializeField] private Rigidbody _sphere;

    private float _speed, _currentSpeed;
    private float _rotate, _currentRotate;
    
    [SerializeField] private float _maxSpeed = 30f;
    [SerializeField] private float _acceleration = 30f;
    [SerializeField] private float _steering = 80f;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _kartNormal;
    [SerializeField] private Transform _bunModel;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _bunTimer;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField, Range(0,1f)] private float _turningSlowdown;
    [SerializeField] private Animator _animator;
    public static bool DONE = false;
    private float _doneTimer;

    void Update()
    {
            _bunTimer += Time.deltaTime;
            _speed = Mathf.Min(_bunTimer / 4f, 1f);
            //Steer
            if (Input.GetAxis("Horizontal") != 0f)
            {
                int dir = Input.GetAxis("Horizontal") > 0 ? 1 : -1;
                float amount = Mathf.Abs((Input.GetAxis("Horizontal")));
                Steer(dir, amount);
                _speed *= 1.0f - amount * _turningSlowdown;
            }

            float turbo = Input.GetAxis("Turbo") * 2f - 1f;
            float accelerationPower = (Mathf.Max(Mathf.Max(Input.GetAxis("L2"), Input.GetAxis("R2")),turbo) + 1f) / 2f;
            
            _speed /= 3.0f - accelerationPower * 2f;
            _speed *= _maxSpeed;
            
            _currentSpeed = Mathf.SmoothStep(_currentSpeed, _speed, Mathf.Min(Mathf.Max(Time.deltaTime * _acceleration,0f),1f));
            _animator.speed = Mathf.Min(_currentSpeed / _maxSpeed * 2f, 1f);
            _speed = 0f;
            _currentRotate = Mathf.Lerp(_currentRotate, _rotate, Time.deltaTime * 64f);
            _rotate = 0f;
            //_bunModel.localEulerAngles = Vector3.LerpUnclamped(_bunModel.localEulerAngles, new Vector3(0, 0 + (Input.GetAxis("Horizontal") * 15), _bunModel.localEulerAngles.z), .1f);

            //_bunModel.localEulerAngles = new Vector3(90f, _bunModel.localEulerAngles.y, _bunModel.localEulerAngles.z);
            transform.position = _sphere.transform.position;
            _camera.position = new Vector3(transform.position.x, _camera.position.y, transform.position.z);
        
    }
    
    private void FixedUpdate()
    {
        if (float.IsNaN(_currentSpeed))
        {
            _currentSpeed = 0f;
        }
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
        _bunModel.position = transform.position;
        _bunModel.rotation = transform.rotation;
        _bunModel.rotation = Quaternion.Euler(90f, _bunModel.rotation.eulerAngles.y + (Input.GetAxis("Horizontal") * 20f), _bunModel.rotation.eulerAngles.z);
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
