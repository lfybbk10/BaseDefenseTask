using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShootHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletPosition;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private float _shootRadius;

    [SerializeField] private float _bulletInterval;
    private Timer _bulletIntervalTimer;

    private void Start()
    {
        PoolManager.WarmPool(_bulletPrefab, 50);
        _bulletIntervalTimer = new Timer(_bulletInterval);
    }


    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _shootRadius, _enemyMask);
        if (colliders.Length > 0)
        {
            _animator.SetBool("RifleRun",true);
            if (_bulletIntervalTimer.UpdateCounter(Time.deltaTime))
            {
                FireBullet(colliders[0].bounds.center);
                transform.DOLookAt(new Vector3(colliders[0].bounds.center.x,0,colliders[0].bounds.center.z), 0.1f,AxisConstraint.Y);
            }
        }
        else
        {
            _animator.SetBool("RifleRun",false);
        }
    }
    
    private void FireBullet(Vector3 enemyPosition)
    {
        var bullet = PoolManager.SpawnObject(_bulletPrefab, _bulletPosition.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Fire(enemyPosition);
    }
}
