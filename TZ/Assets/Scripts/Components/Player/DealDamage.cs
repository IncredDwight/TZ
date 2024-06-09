using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour, IPerformAction
{
    [SerializeField] private float _damage = 10;
    [SerializeField] private int _maxTargetsAmount = 5;

    [SerializeField] private float _frequency = 1.0f;
    private float _timer;

    public void PerformAction(Collider[] targets)
    {
        int targetsAmount = (targets.Length > _maxTargetsAmount) ? _maxTargetsAmount : targets.Length;
        targets = ColliderSorter.GetSortedCollidersByDistance(targets, transform.position);

        if (_timer <= 0)
        {
            for (int i = 0; i < targetsAmount; i++)
            {
                Health health = targets[i].GetComponent<Health>();
                health?.TakeDamage(_damage);
            }
            _timer = _frequency;
        }
        else
            _timer -= Time.deltaTime;
    }
}
