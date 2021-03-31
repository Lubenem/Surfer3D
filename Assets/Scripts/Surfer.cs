using System;
using UnityEngine;

public class Surfer : MonoBehaviour
{
    [SerializeField] private Vector3 _movementVector;
    private Camera mainCamera;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float xAxisLimit = 0.2f;
    [SerializeField] private float DebugXaxis;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        float xAxis = 0f;

        if (Input.GetMouseButton(0))
            xAxis = Input.GetAxis("Mouse X");
        else
            xAxis = 0f;

        Mathf.Clamp(xAxis, -xAxisLimit, xAxisLimit);

        DebugXaxis = xAxis;

        _movementVector = Vector3.Lerp(_movementVector, new Vector3(xAxis, 0f, 0f), _speed * Time.deltaTime);

        transform.Translate(_movementVector);
    }
}