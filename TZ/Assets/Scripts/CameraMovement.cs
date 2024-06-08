using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 3;

    private void FixedUpdate()
    {
        Vector3 targetPosition = _target.position;
        targetPosition.y += 10;
        transform.position = Vector3.Slerp(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}
