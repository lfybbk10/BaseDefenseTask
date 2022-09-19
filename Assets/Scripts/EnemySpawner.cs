using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemySpawnZone;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private int _maxCountEnemies;
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer >= _spawnInterval)
        {
            if (Enemy.Count < _maxCountEnemies)
            {
                GameObject enemy = Instantiate(_enemyPrefab, GetRandomPoint(), Quaternion.identity, _enemySpawnZone.transform);
                enemy.GetComponent<EnemyMoveHandler>().SetEnemyZoneTrigger(_enemySpawnZone.GetComponent<EnemyZoneTrigger>());
            }

            _timer = 0;
        }
    }

    private Vector3 GetRandomPoint()
    {
        Vector3 resPoint = new Vector3();
        var bounds = _enemySpawnZone.GetComponent<BoxCollider>().bounds;
        
        resPoint.x = Random.Range(bounds.min.x, bounds.max.x);
        resPoint.z = Random.Range(bounds.min.z, bounds.max.z);
        resPoint.y = _enemySpawnZone.transform.position.y;
        return resPoint;
    }
}
