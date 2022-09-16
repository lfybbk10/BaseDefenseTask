using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyGround;
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
                GameObject enemy = Instantiate(_enemyPrefab, Vector3.zero, Quaternion.identity);
                enemy.transform.SetParent(_enemyGround.transform);
                enemy.transform.localPosition = GetRandomPoint();
            }

            _timer = 0;
        }
    }

    private Vector3 GetRandomPoint()
    {
        Vector3 resPoint = new Vector3();
        RectTransform groundRectTransform = _enemyGround.GetComponent<RectTransform>();
        
        resPoint.x = Random.Range(-groundRectTransform.anchorMin.x, groundRectTransform.anchorMax.x);
        resPoint.z = Random.Range(-groundRectTransform.anchorMin.y, groundRectTransform.anchorMax.y);
        resPoint.y = groundRectTransform.position.y;
        return resPoint;
    }
}
