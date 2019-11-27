using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed = 3.5f;

    private Vector3 _position;

    [SerializeField]
    private GameObject _laserObject;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        CalculateMovement();
        CreateLaser();
    }

    private void CreateLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_laserObject, transform.position, Quaternion.identity);
        }
    }

    private void CalculateMovement()
    {
        float getHorizontalInput = Input.GetAxis("Horizontal");
        float getVerticalInput = Input.GetAxis("Vertical");

        _position = new Vector3(getHorizontalInput, getVerticalInput, 0);
        transform.Translate(_position * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0));

        if (transform.position.x > 11)
        {
            transform.position = new Vector3(-11.0f, transform.position.y, 0);
        }
        else if (transform.position.x < -11)
        {
            transform.position = new Vector3(11.0f, transform.position.y, 0);
        }
    }
}