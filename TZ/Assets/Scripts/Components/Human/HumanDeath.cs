using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HumanRoaming))]
public class HumanDeath : MonoBehaviour, IDie
{
    private HumanRoaming _humanRoaming;

    private Transform _target;
    private float _speed = 15.0f;
    private float _destroyDistance = 1f;

    private void Awake()
    {
        _humanRoaming = GetComponent<HumanRoaming>();
    }

    private void Update()
    {
        if (_target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * _speed);
            if (Vector3.Distance(transform.position, _target.position) < _destroyDistance)
                Destroy(gameObject);
        }
    }

    public void Die()
    {
        _humanRoaming.enabled = false;
        GameEvents.SendOnHumanDeath();

        _target = FindObjectOfType<PlayerMovement>().transform;
    }
}
