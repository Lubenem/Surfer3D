using System;
using System.Collections.Generic;
using UnityEngine;

public class Surfer : MonoBehaviour
{
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;

    [SerializeField] private SurferCube _surferCubePrefab;
    [SerializeField] private float swerveSpeed = 1.5f;
    [SerializeField] private float maxSwerveAmount = 1.5f;

    public float MoveFactorX => _moveFactorX;

    private void Start()
    {
#if !UNITY_EDITOR
    swerveSpeed = 0.4f;
    maxSwerveAmount = 0.4f;
#endif
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0f;
        }

        Move();
    }

    private void Move()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount, 0, 0);
    }

    public void CollectCube()
    {
        Vector3 newPos = transform.position;
        newPos.y += 0.62f;
        transform.position = newPos;
        SurferCube cube = Instantiate(_surferCubePrefab, transform);
    }

    public void RemoveCube()
    {
        if (transform.childCount <= 0)
            GameManager.instance.FailGame();
    }
}