using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(IInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    private Rigidbody _rigidbody;
    private IInput _input;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _input = GetComponent<IInput>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody.velocity = _speed * new Vector3(
            _input.GetHorizontal(),
            _rigidbody.velocity.y,
            _input.GetVertical());
    }
}
