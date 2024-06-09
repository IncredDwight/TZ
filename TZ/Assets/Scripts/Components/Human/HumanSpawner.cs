using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRadius = 5;
    [SerializeField] private float _frequency = 3.5f;
    [SerializeField] private GameObject _humanPrefab;

    private int _maxAmount = 10;
    private float _timer;

    private bool _isActive;

    private void Awake()
    {
        Spawn(_maxAmount);
        GameEvents.OnHumanDeath += SetSpawnActiveStatus;
    }

    private void OnDestroy()
    {
        GameEvents.OnHumanDeath -= SetSpawnActiveStatus;
    }

    private void Update()
    {
        if(_isActive)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                Spawn();
                _timer = _frequency;
            }
        }
    }

    private void Spawn(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 position = Random.insideUnitSphere * _spawnRadius;
            position.y = 0;

            Instantiate(_humanPrefab, position, Quaternion.identity);
        }
        SetSpawnActiveStatus();
    }

    private void SetSpawnActiveStatus()
    {
        int humansCount = FindObjectsOfType<HumanDeath>().Length;
        _isActive = humansCount < _maxAmount;
    }
}
