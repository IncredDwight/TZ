using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HumanRoaming : MonoBehaviour
{
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _frequency = 5.0f;
    [SerializeField] private float _roamingRadius = 5.0f;
    private float _timer;

    private Rigidbody _rigidbody;

    private Vector3 _targetDirection = Vector3.zero;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Roam();
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
    }

    public void Roam()
    {
        if(_timer <= 0)
        {
            _targetDirection = GetNextRoamingDirection();
            _timer = _frequency;
        }
        _rigidbody.velocity = _speed * new Vector3(_targetDirection.x, _rigidbody.velocity.y, _targetDirection.z);
    }

    private Vector3 GetNextRoamingDirection()
    {
        Vector3 direction = Random.insideUnitSphere;
        direction.y = 0;
        return direction;
    }
}
