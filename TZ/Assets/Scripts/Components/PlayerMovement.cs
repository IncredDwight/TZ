using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    private Rigidbody _rigidbody;
    private Vector2 _input;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");
    }

    private void Move()
    {
        _rigidbody.velocity = _speed * new Vector3(
            _input.x,
            _rigidbody.velocity.y,
            _input.y);
    }
}
