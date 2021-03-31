using UnityEngine;

public class MapMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private void Update()
    {
        transform.Translate(new Vector3(0f, 0f, -1f) * _speed * Time.deltaTime);
    }
}