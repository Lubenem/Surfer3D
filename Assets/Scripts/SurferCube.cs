using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurferCube : MonoBehaviour
{
    private Surfer _surfer;

    [SerializeField] private float minCollideYDiff = 0.1f;

    private void Start()
    {
        _surfer = GetComponentInParent<Surfer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Cube":
                CollectCube(other.transform);
                break;
            case "Obstacle":
                RemoveCube(other.transform);
                break;
            case "Finish":
                GameManager.instance.CompleteGame();
                break;
        }
    }

    private void RemoveCube(Transform other)
    {
        float Ydiff = Mathf.Abs(transform.position.y - other.position.y);
        if (Ydiff >= minCollideYDiff)
            return;

        transform.parent = other.transform.parent;
        _surfer.RemoveCube();
    }

    private void CollectCube(Transform other)
    {
        other.gameObject.SetActive(false);
        _surfer.CollectCube();
    }
}
