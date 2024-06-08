using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IPerformAction))]
public class PerformActionsInRange : MonoBehaviour
{
    [SerializeField] private float _radius = 5.0f;
    [SerializeField] private float _frequency = 1.0f;
    private float _timer = 0;

    private IPerformAction[] _actions;

    private void Awake()
    {
        _actions = GetComponents<IPerformAction>();
    }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        Perform(colliders);
    }

    private void Perform(Collider[] targets)
    {
        foreach (IPerformAction action in _actions)
                action.PerformAction(targets);
        _timer = _frequency;
    }
}
