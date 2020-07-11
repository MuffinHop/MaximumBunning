using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private float _bunTimer;
    [SerializeField] private float _startingLineTimer;
    [SerializeField] private Transform _infoText;
    [SerializeField] private TextMeshProUGUI _readySetGoText;
    [SerializeField] private TextMeshProUGUI _countDownText;
    void Update()
    {
        if (_startingLineTimer > 7f)
        {
            _countDownText.gameObject.SetActive(true);
            _readySetGoText.gameObject.SetActive(false);
            _bunTimer += Time.deltaTime;
            _countDownText.text = (int)(120 - _bunTimer) + " SECONDS";
            _speed = _acceleration * Mathf.Min(_bunTimer / 4f, 1f);

            //Steer
            if (Input.GetAxis("Horizontal") != 0f)
            {
                int dir = Input.GetAxis("Horizontal") > 0 ? 1 : -1;
                float amount = Mathf.Abs((Input.GetAxis("Horizontal")));
                Steer(dir, amount);
            }

            _currentSpeed = Mathf.SmoothStep(_currentSpeed, _speed, Time.deltaTime * 12f);
            _speed = 0f;
            _currentRotate = Mathf.Lerp(_currentRotate, _rotate, Time.deltaTime * 4f);
            _rotate = 0f;
            //_bunModel.localEulerAngles = Vector3.LerpUnclamped(_bunModel.localEulerAngles, new Vector3(0, 0 + (Input.GetAxis("Horizontal") * 15), _bunModel.localEulerAngles.z), .2f);
            _bunModel.localEulerAngles = new Vector3(90f, _bunModel.localEulerAngles.y, _bunModel.localEulerAngles.z);
            transform.position = _sphere.transform.position;
            _camera.position = new Vector3(transform.position.x, _camera.position.y, transform.position.z);
        }
        else
        {
            _countDownText.gameObject.SetActive(false);
            if (_startingLineTimer < 4.0f)
            {
                _readySetGoText.gameObject.SetActive(false);
                _infoText.gameObject.SetActive(true);
            }
            else
            {
                _readySetGoText.gameObject.SetActive(true);
                if (_startingLineTimer < 5.0f)
                {
                    _readySetGoText.text = "READY";
                } else if (_startingLineTimer < 6.0f)
                {
                    _readySetGoText.text = "SET";
                } else if (_startingLineTimer < 7.0f)
                {
                    _readySetGoText.text = "GO";
                }
                _infoText.gameObject.SetActive(false);
            }

        }
        _startingLineTimer += Time.deltaTime;
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
